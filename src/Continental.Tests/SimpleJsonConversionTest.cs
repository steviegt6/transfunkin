using System;
using System.Collections.Generic;
using System.Linq;
using Continental.API;
using Continental.API.Impl;
using Continental.Extensions;
using NUnit.Framework;

namespace Continental.Tests
{
    public static class SimpleJsonConversionTest
    {
        #region Class Definitions
        
        public abstract class BaseJson : IConvertableJson
        {
            public abstract List<IConvertableParameter> GetParameters();

            public abstract void Convert(IReadOnlyCollection<IConvertableParameter> parameters);

            public T GetParameter<T>(IReadOnlyCollection<IConvertableParameter> parameters, string name) =>
                GetParam<T>(parameters, name);
        }

        public class FooJson : BaseJson
        {
            public string Hi;
            public string Hello;
            public int What;

            public override List<IConvertableParameter> GetParameters() => new()
            {
                new ConvertableParameter<string>(nameof(Hi), Hi),
                new ConvertableParameter<string>(nameof(Hello), Hello),
                new ConvertableParameter<int>(nameof(What), What),
            };

            public override void Convert(IReadOnlyCollection<IConvertableParameter> parameters)
            {
                Hi = GetParameter<string>(parameters, nameof(Hi));
                Hello = GetParameter<string>(parameters, nameof(Hello));
                What = GetParameter<int>(parameters, nameof(What));
            }

            public override string ToString() => $"Hi: {Hi}, Hello: {Hello}, What: {What}";
        }

        public class BarJson : BaseJson
        {
            public string Hi;
            public string Hello;
            public string What; // string instead of int ooh 

            public override List<IConvertableParameter> GetParameters() => new()
            {
                new ConvertableParameter<string>(nameof(Hi), Hi),
                new ConvertableParameter<string>(nameof(Hello), Hello),
                new ConvertableParameter<string>(nameof(What), What),
            };

            public override void Convert(IReadOnlyCollection<IConvertableParameter> parameters)
            {
                Hi = GetParameter<string>(parameters, nameof(Hi));
                Hello = GetParameter<string>(parameters, nameof(Hello));
                What = GetParameter<string>(parameters, nameof(What));
            }

            public override string ToString() => $"Hi: {Hi}, Hello: {Hello}, What: {What}";
        }

        public class FooToBarHandler : IConversionHandler<FooJson, BarJson>
        {
            public List<IConvertableParameter> Convert(List<IConvertableParameter> input)
            {
                List<IConvertableParameter> parameters = new();
                parameters.Add(new ConvertableParameter<string>("Hi", GetParam<string>(input, "Hi")));
                parameters.Add(new ConvertableParameter<string>("Hello", GetParam<string>(input, "Hello")));
                parameters.Add(new ConvertableParameter<string>("What", GetParam<int>(input, "What").ToString()));

                return parameters;
            }
        }

        public class BarToFooHandler : IConversionHandler<BarJson, FooJson>
        {
            public List<IConvertableParameter> Convert(List<IConvertableParameter> input)
            {
                List<IConvertableParameter> parameters = new();
                parameters.Add(new ConvertableParameter<string>("Hi", GetParam<string>(input, "Hi")));
                parameters.Add(new ConvertableParameter<string>("Hello", GetParam<string>(input, "Hello")));

                int what = int.Parse(GetParam<string>(input, "What"));
                parameters.Add(new ConvertableParameter<int>("What", what));

                return parameters;
            }
        }
        
        #endregion

        [Test]
        public static void TestFooAndBar()
        {
            IJsonConverter converter = new StandardJsonConverter();
            converter.RegisterHandler(new FooToBarHandler());
            converter.RegisterHandler(new BarToFooHandler());

            FooJson fromFoo = new()
            {
                Hi = "HI THERE",
                Hello = "WELL HELLO",
                What = 5
            };
            IConvertableJson toBar = new BarJson();
            converter.Convert(fromFoo, ref toBar);
            AssetEqualsPrint(toBar.ToString()!, "Hi: HI THERE, Hello: WELL HELLO, What: 5");

            BarJson fromBar = new()
            {
                Hi = "HI HI HI",
                Hello = "HELLO HELLO",
                What = "10"
            };
            IConvertableJson toFoo = new FooJson();
            converter.Convert(fromBar, ref toFoo);
            AssetEqualsPrint(toFoo.ToString()!, "Hi: HI HI HI, Hello: HELLO HELLO, What: 10");

        }

        public static T GetParam<T>(IEnumerable<IConvertableParameter> parameters, string name) =>
            (T?) parameters.First(x => x.ParameterName == name && x.Type.IsOrIsSubclassOf(typeof(T))).Value ??
            throw new Exception();

        public static void AssetEqualsPrint(string one, string two)
        {
            Console.WriteLine($"Asserting: \"{one}\" == \"{two}\"");
            Assert.AreEqual(one, two);
        }
    }
}