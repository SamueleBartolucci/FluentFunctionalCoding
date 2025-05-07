namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents an optional value of type <typeparamref name="O"/>. This is the base type for Some and None.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Throws a NotImplementedException for unknown optional types.
        /// </summary>
        /// <returns>NotImplementedException with a descriptive message.</returns>
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(Some<O>)} or {nameof(None<O>)}");

        /// <summary>
        /// Gets a value indicating whether the Optional contains a value (is Some).
        /// </summary>
        public abstract bool IsSome { get; }

        /// <summary>
        /// Gets a value indicating whether the Optional is None (does not contain a value).
        /// </summary>
        public bool IsNone => !IsSome;
    }
}
