using System;

namespace Continental.API
{
    /// <summary>
    ///     Represents a parameter of a <see cref="IConvertableJson"/> JSON file.
    /// </summary>
    public interface IConvertableParameter<out T> : IConvertableParameter
    {
        /// <summary>
        ///     The value of this parameter.
        /// </summary>
        new T Value { get; }
        
        object? IConvertableParameter.Value => Value;

        Type IConvertableParameter.Type => typeof(T);
    }
    
    /// <summary>
    ///     Represents a parameter of a <see cref="IConvertableJson"/> JSON file.
    /// </summary>
    public interface IConvertableParameter
    {
        /// <summary>
        ///     The parameter's name.
        /// </summary>
        string ParameterName { get; }

        /// <summary>
        ///     The value of this parameter.
        /// </summary>
        object? Value { get; }

        /// <summary>
        ///     The <see cref="System.Type"/> of this parameter.
        /// </summary>
        Type Type { get; }
    }
}