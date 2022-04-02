using System;
using System.IO;
using Continental.Exceptions;

namespace Continental.API.Impl
{
    /// <summary>
    ///     Provides a <see cref="Stream"/> passed in the constructor.
    /// </summary>
    public class StreamStreamProvider : IStreamProvider
    {
        public Stream Stream { get; protected set; }

        /// <summary>
        ///     Constructs a provider pointing to the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> instance to return.</param>
        public StreamStreamProvider(Stream stream)
        {
            Stream = stream;
        }

        public virtual Stream GetStream(StreamOpenMode openMode)
        {
            return openMode switch
            {
                StreamOpenMode.Read when !Stream.CanRead => throw new StreamProviderException(
                    "Could not provide stream - not readable."
                ),
                StreamOpenMode.Write when !Stream.CanWrite => throw new StreamProviderException(
                    "Could not provide stream - not writable."
                ),
                StreamOpenMode.Both when !Stream.CanRead || !Stream.CanWrite => throw new StreamProviderException(
                    "Could not provide stream - not readable or/nor writable."
                ),
                StreamOpenMode.Read => Stream,
                StreamOpenMode.Write => Stream,
                StreamOpenMode.Both => Stream,
                _ => throw new ArgumentOutOfRangeException(nameof(openMode), openMode, null)
            };
        }
    }
}