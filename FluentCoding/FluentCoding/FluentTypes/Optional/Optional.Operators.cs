using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace FluentCoding
{
    public abstract partial record Optional<O> : IOptional<O>
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Optional<O>(O input) => (input == null ? None() : Some(input)) as Optional<O>;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(Optional<O> input) => input.IsSome;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator true(Optional<O> value) => value.IsSome;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator false(Optional<O> value) => value.IsNone;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !(Optional<O> value) => value.IsNone;
    }
}
