using System.Collections.Generic;

namespace Continental.API
{
    /// <summary>
    ///     Represents an object tasked with handling the conversion of <see cref="IConvertableJson"/> JSON files.
    /// </summary>
    public interface IJsonConverter
    {
        /// <summary>
        ///     The handlers to use.
        /// </summary>
        IReadOnlyCollection<IConversionHandler> ConversionHandlers { get; }

        /// <summary>
        ///     Registers this handler.
        /// </summary>
        /// <param name="handler">The handler to register.</param>
        void RegisterHandler(IConversionHandler handler);

        /// <summary>
        ///     Retrieves all conversion handlers that should be used in this conversion process.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerable<IConversionHandler> GetConversionHandlers(IConvertableJson from, IConvertableJson to);

        /// <summary>
        ///     Converts the instance of JSON file <paramref cref="from"/> into an instance of JSON file <paramref cref="to"/>. <br />
        ///     <paramref cref="to"/> has its members updated appropriately.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void Convert(in IConvertableJson from, ref IConvertableJson to);
    }
}