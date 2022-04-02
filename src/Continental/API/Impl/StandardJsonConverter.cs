using System.Collections.Generic;
using System.Linq;
using Continental.Extensions;

namespace Continental.API.Impl
{
    /// <summary>
    ///     Type-dependent <see cref="IJsonConverter"/> implementation.
    /// </summary>
    public class StandardJsonConverter : IJsonConverter
    {
        protected readonly List<IConversionHandler> Handlers = new();

        public IReadOnlyCollection<IConversionHandler> ConversionHandlers => Handlers.AsReadOnly();

        public virtual void RegisterHandler(IConversionHandler handler) => Handlers.Add(handler);

        public virtual IEnumerable<IConversionHandler> GetConversionHandlers(
            IConvertableJson from,
            IConvertableJson to
        ) => ConversionHandlers.Where(
            // Return all types that use types subclassing the from and to inputs.
            handler => handler.FromType.IsOrIsSubclassOf(from.GetType()) && handler.ToType.IsOrIsSubclassOf(to.GetType())
        );

        public virtual void Convert(in IConvertableJson from, ref IConvertableJson to)
        {
            List<IConvertableParameter> parameters = from.GetParameters();

            // ReSharper disable once LoopCanBeConvertedToQuery - Disgustingly ugly OOP code.
            foreach (IConversionHandler handler in GetConversionHandlers(from, to))
                parameters = handler.Convert(parameters);
            
            to.Convert(parameters);
        }
    }
}