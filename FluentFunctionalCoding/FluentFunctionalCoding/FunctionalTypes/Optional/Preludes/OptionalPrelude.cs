namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension and factory methods for creating Optional values in a fluent style.
    /// </summary>
    public static partial class Prelude
    {        
        /// <summary>
        /// Wraps a value in an Optional as Some. Equivalent to Optional.Some(value).
        /// </summary>
        /// <typeparam name="O">The type of the value.</typeparam>
        /// <param name="value">The value to wrap.</param>
        /// <returns>An Optional containing the value as Some.</returns>
        public static Optional<O> Optional<O>(this O value) => FluentFunctionalCoding.Optional<O>.Some(value);

        /// <summary>
        /// Returns an Optional representing None (no value).
        /// </summary>
        /// <typeparam name="O">The type of the value.</typeparam>
        /// <returns>An Optional with no value.</returns>
        public static Optional<O> OptionalNone<O>() => FluentFunctionalCoding.Optional<O>.None();

    }
}
