namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(Some<O>)} or {nameof(None<O>)}");

        internal static Optional<O> None() => new None<O>();

        internal static Optional<O> Some(O value) => value == null ?
                                                            new None<O>() :
                                                            new Some<O>(value);

        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public bool IsSome => this switch
        {
            Some<O> => true,
            None<O> => false,
            _ => throw UnknowOptionalType()
        };


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => this switch
        {
            Some<O> => false,
            None<O> => true,
            _ => throw UnknowOptionalType()
        };

    }
}
