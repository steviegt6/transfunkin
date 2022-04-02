namespace Continental
{
    /// <summary>
    ///     Details how a stream should be opened.
    /// </summary>
    /// <remarks>
    ///     Even if <see cref="Read"/> or <see cref="Write"/> is passed, a stream may have both read and write access.
    /// </remarks>
    public enum StreamOpenMode
    {
        /// <summary>
        ///     Opens a stream when only read access is required.
        /// </summary>
        Read,
        
        /// <summary>
        ///     Opens a stream when only write access is required.
        /// </summary>
        Write,
        
        /// <summary>
        ///     Opens a stream when read and write access is required.
        /// </summary>
        Both
    }
}