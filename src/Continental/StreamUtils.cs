using System.IO;
using Continental.API;
using Continental.Impl;

namespace Continental
{
    /// <summary>
    ///     Various utilities for handling streams.
    /// </summary>
    public static class StreamUtils
    {
        /// <summary>
        ///     Instantiates a <see cref="FileStreamProvider"/> to be used. Reads from the <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to read from.</param>
        public static IStreamProvider ProviderFromFile(string path) => new FileStreamProvider(path);

        /// <summary>
        ///     Retrieves a <see cref="Stream"/> from the <paramref name="path"/> using a <see cref="IStreamProvider"/> from <see cref="ProviderFromFile"/> instead of opening it regularly.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream StreamFromFile(string path) => new FileStreamProvider(path).GetStream(StreamOpenMode.Both);
    }
}