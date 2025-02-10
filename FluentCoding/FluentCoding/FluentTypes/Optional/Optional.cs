using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(OptionalJust<O>)} or {nameof(OptionalNone<O>)}");

        internal static Optional<O> None() => new OptionalNone<O>();

        internal static Optional<O> Some(O value) => value == null? 
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
            _ => throw UnknowOptionalType()
        };


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => this switch
        {
            OptionalJust<O> => false,
            OptionalNone<O> => true,
            _ => throw UnknowOptionalType()
        };

    }
}
