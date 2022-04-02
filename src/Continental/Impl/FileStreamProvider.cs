using System;
using System.IO;
using Continental.API;

namespace Continental.Impl
{
    /// <summary>
    ///     Provides a <see cref="Stream"/> given a <see cref="FileInfo"/> instance or path.
    /// </summary>
    public class FileStreamProvider : IStreamProvider
    {
        /// <summary>
        ///     The <see cref="System.IO.FileInfo"/> pointing to the file to open.
        /// </summary>
        public FileInfo FileInfo { get; protected set; }
        
        /// <summary>
        ///     Constructs a provider pointing to the file located at <paramref name="fileInfo"/>.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> instance pointing to the file.</param>
        public FileStreamProvider(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        /// <summary>
        ///     Constructs a provider pointing to the file located at <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        public FileStreamProvider(string path)
        {
            FileInfo = new FileInfo(path);
        }

        public virtual Stream GetStream(StreamOpenMode openMode)
        {
            return openMode switch
            {
                StreamOpenMode.Read => FileInfo.OpenRead(),
                StreamOpenMode.Write => FileInfo.OpenWrite(),
                StreamOpenMode.Both => FileInfo.Open(FileMode.Create, FileAccess.ReadWrite),
                _ => throw new ArgumentOutOfRangeException(nameof(openMode), openMode, null)
            };
        }
    }
}