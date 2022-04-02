using System;

namespace Continental.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="Type"/>.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Returns whether the two types are equal or if <paramref name="left"/> subclasses <paramref name="right"/>.
        /// </summary>
        public static bool IsOrIsSubclassOf(this Type left, Type right) => left == right || left.IsSubclassOf(right);
    }
}