using System.Collections.Generic;

namespace Continental.API
{
    /// <summary>
    ///     Represents a JSON file that can be converted to another JSON file format using <see cref="IConvertableParameter"/>s.
    /// </summary>
    public interface IConvertableJson
    {
        /// <summary>
        ///     Handles converting a collection of <see cref="IConvertableParameter"/>s. <see cref="IConversionHandler"/>s deal with transferring data to these parameters. 
        /// </summary>
        /// <param name="parameters">The parameters to use.</param>
        void Convert(IReadOnlyCollection<IConvertableParameter> parameters);
    }
}