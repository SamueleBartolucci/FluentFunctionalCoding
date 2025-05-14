namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Matches the outcome and executes the corresponding function for success or failure.
        /// </summary>
        /// <typeparam name="M">The return type of the match function.</typeparam>
        /// <param name="onSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="onFailure">Function to execute if the outcome is a failure.</param>
        /// <returns>The result of the executed function.</returns>
        public M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure) => this switch
        {
            Right<F, S>(var s) => onSuccess(s),
            Left<F, S>(var f) => onFailure(f),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Matches the outcome and executes the success function or returns a value on failure.
        /// </summary>
        /// <typeparam name="M">The return type of the match function.</typeparam>
        /// <param name="onSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="valueOnFailure">Value to return if the outcome is a failure.</param>
        /// <returns>The result of the executed function or the value on failure.</returns>
        public M Match<M>(Func<S, M> onSuccess, M valueOnFailure) => this switch
        {
            Right<F, S>(var s) => onSuccess(s),
            Left<F, S>(_) => valueOnFailure,
            _ => throw UnknownOutcomeType()
        };
    }
}
