namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides factory methods for creating Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Returns an Optional representing None (no value).
        /// </summary>
        /// <returns>An Optional with no value.</returns>
        public static Optional<O> None() => new None<O>();

        /// <summary>
        /// Returns an Optional representing Some(value) if value is not null; otherwise returns None.
        /// </summary>
        /// <param name="value">The value to wrap in an Optional.</param>
        /// <returns>An Optional containing the value, or None if value is null.</returns>
        public static Optional<O> Some(O value) => value == null ?
                                                            new None<O>() :
                                                            new Some<O>(value);
    }
}
