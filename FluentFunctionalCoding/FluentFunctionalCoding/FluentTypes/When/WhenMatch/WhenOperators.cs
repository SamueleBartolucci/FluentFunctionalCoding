using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public partial record When<T>
    {

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator true(When<T> value) => value.IsTrue;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator false(When<T> value) => value.IsFalse;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !(When<T> value) => value.IsFalse;
    }
}
