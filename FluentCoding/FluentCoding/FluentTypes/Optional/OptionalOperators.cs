using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace FluentCoding
{
    public readonly partial struct Optional<O>
    {

        //[Pure]
        //public static explicit operator O(Optional<O> input) => input.IsSome ? input._subject : default(O);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Optional<O>(O input) => input == null ? None() : Some(input);

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
