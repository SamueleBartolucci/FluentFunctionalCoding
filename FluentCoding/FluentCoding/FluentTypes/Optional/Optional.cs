using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(OptionalJust<O>)} or {nameof(OptionalNone<O>)}");

        public static Optional<O> None() => new OptionalNone<O>();

        public static Optional<O> Some(O value) => value == null? 
                                                            new OptionalNone<O>() : 
                                                            new OptionalJust<O>(value);
                
        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public bool IsSome => this switch
        {
            OptionalJust<O> => true,
            OptionalNone<O> => false,
            _ => throw UnknowImplementation()
        };


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => this switch
        {
            OptionalJust<O> => false,
            OptionalNone<O> => true,
            _ => throw UnknowImplementation()
        };

    }
}
