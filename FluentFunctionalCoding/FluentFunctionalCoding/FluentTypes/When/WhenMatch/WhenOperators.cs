using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public partial record When<T>
    {

        /// <summary>
        /// Determines whether the <see cref="When{T}"/> instance is considered true.
        /// </summary>
        /// <param name="value">The <see cref="When{T}"/> instance.</param>
        /// <returns>True if the condition is true; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator true(When<T> value) => value.IsTrue;

        /// <summary>
        /// Determines whether the <see cref="When{T}"/> instance is considered false.
        /// </summary>
        /// <param name="value">The <see cref="When{T}"/> instance.</param>
        /// <returns>True if the condition is false; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator false(When<T> value) => value.IsFalse;

        /// <summary>
        /// Negates the condition of the <see cref="When{T}"/> instance.
        /// </summary>
        /// <param name="value">The <see cref="When{T}"/> instance.</param>
        /// <returns>True if the condition is false; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !(When<T> value) => value.IsFalse;
    }
}
