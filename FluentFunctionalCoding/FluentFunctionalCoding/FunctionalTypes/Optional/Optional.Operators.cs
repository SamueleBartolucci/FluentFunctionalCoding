using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides operator overloads and implicit conversions for Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Implicitly converts a value to an Optional. Returns None if the value is null, otherwise Some(value).
        /// </summary>
        /// <param name="input">The value to convert.</param>
        /// <returns>An Optional representing the value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Optional<O>(O input) => (input == null ? None() : Some(input)) as Optional<O>;

        /// <summary>
        /// Implicitly converts an Optional to a boolean indicating if it is Some.
        /// </summary>
        /// <param name="input">The Optional to check.</param>
        /// <returns>True if the Optional is Some; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(Optional<O> input) => input.IsSome;

        /// <summary>
        /// Operator true: returns true if the Optional is Some.
        /// </summary>
        /// <param name="value">The Optional to check.</param>
        /// <returns>True if the Optional is Some; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator true(Optional<O> value) => value.IsSome;

        /// <summary>
        /// Operator false: returns true if the Optional is None.
        /// </summary>
        /// <param name="value">The Optional to check.</param>
        /// <returns>True if the Optional is None; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator false(Optional<O> value) => value.IsNone;

        /// <summary>
        /// Logical negation operator: returns true if the Optional is None.
        /// </summary>
        /// <param name="value">The Optional to check.</param>
        /// <returns>True if the Optional is None; otherwise, false.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !(Optional<O> value) => value.IsNone;
    }
}
