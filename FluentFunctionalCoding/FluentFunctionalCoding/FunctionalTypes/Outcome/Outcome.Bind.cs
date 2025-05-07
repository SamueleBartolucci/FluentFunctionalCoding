namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for binding operations on Outcome.
    /// </summary>
    /// <typeparam name="F">The type of the failure value.</typeparam>
    /// <typeparam name="S">The type of the success value.</typeparam>
    public abstract partial record Outcome<F, S>//  : Outcome<F, S>
    {
        /// <summary>
        /// Binds the outcome to a new outcome if it is a success.
        /// </summary>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="bindOnSuccess">Function to apply if the outcome is a success.</param>
        /// <returns>A new Outcome based on the result of the function.</returns>
        public Outcome<F, S1> Bind<S1>(Func<S, Outcome<F, S1>> bindOnSuccess) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => Outcome<F, S1>.Left(f),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Binds the outcome to a new outcome if it is a failure.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <param name="bindOnFailure">Function to apply if the outcome is a failure.</param>
        /// <returns>A new Outcome based on the result of the function.</returns>
        public Outcome<F1, S> BindFailure<F1>(Func<F, Outcome<F1, S>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Right(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Binds the outcome to new outcomes for both success and failure cases.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="bindOnSuccess">Function to apply if the outcome is a success.</param>
        /// <param name="bindOnFailure">Function to apply if the outcome is a failure.</param>
        /// <returns>A new Outcome based on the result of the functions.</returns>
        public Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };
    }
}
