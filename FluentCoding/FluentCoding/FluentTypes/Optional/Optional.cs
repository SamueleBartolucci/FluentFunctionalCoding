using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(Just<O>)} or {nameof(Nothing<O>)}");

        public static Optional<O> None() => new Nothing<O>();

        public static Optional<O> Some(O value) => value == null? None() : new Just<O>(value);


        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public bool IsSome => this switch
        {
            Just<O> => true,
            Nothing<O> => false,
            _ => throw UnknowImplementation()
        };


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => this switch
        {
            Just<O> => true,
            Nothing<O> => false,
            _ => throw UnknowImplementation()
        };
    }
}
