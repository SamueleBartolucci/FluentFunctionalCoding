namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Converts the outcome to an Optional containing the success value if present.
        /// </summary>
        /// <returns>An Optional containing the success value, or None if failure.</returns>
        public Optional<S> ToOptional() => this switch
        {
            Right<F, S>(var s) => Optional<S>.Some(s),
            _ => Optional<S>.None()
        };

        /// <summary>
        /// Converts the outcome to an Optional containing the failure value if present.
        /// </summary>
        /// <returns>An Optional containing the failure value, or None if success.</returns>
        public Optional<F> ToOptionalFailure() => this switch
        {
            Left<F, S>(var f) => Optional<F>.Some(f),
            _ => Optional<F>.None(),
        };
    }
}
