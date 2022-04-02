using System.IO;

namespace Continental.API
{
    /// <summary>
    ///     Provides a <see cref="Stream"/> to be used for conversion.
    /// </summary>
    public interface IStreamProvider
    {
        /// <summary>
        ///     Opens a stream.
        /// </summary>
        /// <param name="openMode">The <see cref="StreamOpenMode"/> to use when opening this stream.</param>
        /// <returns>Returns the opened stream.</returns>
        Stream GetStream(StreamOpenMode openMode);
    }
}