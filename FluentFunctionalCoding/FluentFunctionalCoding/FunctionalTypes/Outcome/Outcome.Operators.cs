namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Defines an explicit conversion from a success value to an Outcome.
        /// </summary>
        /// <param name="success">The success value.</param>
        /// <returns>An Outcome representing success.</returns>
        public static explicit operator Outcome<F, S>(S success) => Right(success) as Outcome<F, S>;
        /// <summary>
        /// Defines an explicit conversion from a failure value to an Outcome.
        /// </summary>
        /// <param name="failure">The failure value.</param>
        /// <returns>An Outcome representing failure.</returns>
        public static explicit operator Outcome<F, S>(F failure) => Left(failure) as Outcome<F, S>;

        /// <summary>
        /// Returns true if the outcome is a success.
        /// </summary>
        /// <param name="value">The outcome to evaluate.</param>
        /// <returns>True if the outcome is a success; otherwise, false.</returns>
        public static bool operator true(Outcome<F, S> value) => value.IsSuccess;
        /// <summary>
        /// Returns true if the outcome is a failure.
        /// </summary>
        /// <param name="value">The outcome to evaluate.</param>
        /// <returns>True if the outcome is a failure; otherwise, false.</returns>
        public static bool operator false(Outcome<F, S> value) => value.IsFailure;
        /// <summary>
        /// Returns true if the outcome is a failure.
        /// </summary>
        /// <param name="value">The outcome to evaluate.</param>
        /// <returns>True if the outcome is a failure; otherwise, false.</returns>
        public static bool operator !(Outcome<F, S> value) => value.IsFailure;
    }
}
