using System;
using Continental.API;

namespace Continental
{
    /// <summary>
    ///     Represents a parameter of a JSON file belonging to a <see cref="IConvertableJson"/>.
    /// </summary>
    /// <param name="ParameterName">The parameter's name.</param>
    /// <param name="Value">The value of this parameter.</param>
    /// <remarks>
    ///     Data is provided for easily identifying parameters in handlers.
    /// </remarks>
    public readonly record struct ConvertableParameter<T>(string ParameterName, T Value)
    {
        /// <summary>
        ///     The <see cref="System.Type"/> of this parameter.
        /// </summary>
        public Type Type => typeof(T);
    }
}