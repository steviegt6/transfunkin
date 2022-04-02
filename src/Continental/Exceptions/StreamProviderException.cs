using System;
using System.IO;
using Continental.API;

namespace Continental.Exceptions
{
    /// <summary>
    ///     Thrown if a <see cref="IStreamProvider"/> cannot provide a <see cref="Stream"/>.
    /// </summary>
    public class StreamProviderException : Exception
    {
        public StreamProviderException(string? message = null, Exception? exception = null) : base(message, exception)
        {
        }
    }
}