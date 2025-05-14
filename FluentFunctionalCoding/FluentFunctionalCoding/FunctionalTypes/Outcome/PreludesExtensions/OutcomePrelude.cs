namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Converts a value to a successful <see cref="Outcome{F, S}"/> (Right).
        /// </summary>
        /// <typeparam name="F">The type of the failure value.</typeparam>
        /// <typeparam name="S">The type of the success value.</typeparam>
        /// <param name="success">The value to wrap as a successful outcome.</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing success.</returns>
        public static Outcome<F, S> ToOutcome<F, S>(this S success) => Prelude.Outcome<F, S>(success);

        /// <summary>
        /// Converts a value to a failed <see cref="Outcome{F, S}"/> (Left).
        /// </summary>
        /// <typeparam name="F">The type of the failure value.</typeparam>
        /// <typeparam name="S">The type of the success value.</typeparam>
        /// <param name="failure">The value to wrap as a failure outcome.</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing failure.</returns>
        public static Outcome<F, S> ToOutcomeFailure<F, S>(this F failure) => Prelude.OutcomeFailure<F, S>(failure);

        /// <summary>
        /// Converts a value to an <see cref="Outcome{F, S}"/> using a predicate to determine failure.
        /// </summary>
        /// <typeparam name="F">The type of the failure value.</typeparam>
        /// <typeparam name="S">The type of the success value.</typeparam>
        /// <param name="value">The value to wrap.</param>
        /// <param name="isFailureWhen">A function that returns true if the value should be considered a failure.</param>
        /// <param name="failureValue">The value to use if the predicate returns true (failure).</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing success or failure.</returns>
        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<bool> isFailureWhen, F failureValue) => Prelude.Outcome(value, isFailureWhen, failureValue);

        /// <summary>
        /// Converts a value to an <see cref="Outcome{F, S}"/> using a predicate on the value to determine failure.
        /// </summary>
        /// <typeparam name="F">The type of the failure value.</typeparam>
        /// <typeparam name="S">The type of the success value.</typeparam>
        /// <param name="value">The value to wrap.</param>
        /// <param name="isFailureWhen">A function that takes the value and returns true if it should be considered a failure.</param>
        /// <param name="failureValue">The value to use if the predicate returns true (failure).</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing success or failure.</returns>
        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<S, bool> isFailureWhen, F failureValue) => Prelude.Outcome(value, isFailureWhen, failureValue);
    }
}
