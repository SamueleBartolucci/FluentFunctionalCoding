namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(Some<O>)} or {nameof(None<O>)}");

        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public abstract bool IsSome { get; }


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => !IsSome;
    }
}
