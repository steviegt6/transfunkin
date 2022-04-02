using System.Collections.Generic;

namespace Continental.API
{
    /// <summary>
    ///     Represents an object tasked with handling the conversion of <see cref="IConvertableJson"/> JSON files.
    /// </summary>
    public interface IJsonConverter
    {
        /// <summary>
        ///     Converts the instance of JSON file <paramref cref="from"/> into an instance of JSON file <paramref cref="to"/>. <br />
        ///     <paramref cref="to"/> has its members updated appropriately.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void Convert(in IConvertableJson from, ref IConvertableJson to);
    }
}