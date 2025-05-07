namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Executes the provided functions depending on whether the outcome is success or failure.
        /// </summary>
        /// <typeparam name="X">The return type for the success function.</typeparam>
        /// <typeparam name="Y">The return type for the failure function.</typeparam>
        /// <param name="doOnSuccess">Function to execute if the outcome is a success.</param>
        /// <param name="doOnFailure">Function to execute if the outcome is a failure.</param>
        /// <returns>The original outcome after executing the functions.</returns>
        public Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure) => this switch
        {
            Right<F, S> r => r.Do(doOnSuccess),
            Left<F, S>(var l) => l.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Executes the provided function if the outcome is a success.
        /// </summary>
        /// <typeparam name="X">The return type for the success function.</typeparam>
        /// <param name="funcAsDoOnSuccess">Function to execute if the outcome is a success.</param>
        /// <returns>The original outcome after executing the function.</returns>
        public Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess) => this switch
        {
            Right<F, S> r => r.Do(funcAsDoOnSuccess),
            Left<F, S> l => l,
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Executes the provided function if the outcome is a failure.
        /// </summary>
        /// <typeparam name="Y">The return type for the failure function.</typeparam>
        /// <param name="funcAsDoOnFailure">Function to execute if the outcome is a failure.</param>
        /// <returns>The original outcome after executing the function.</returns>
        public Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure) => this switch
        {
            Right<F, S> r => r,
            Left<F, S>(var l) => l.Do(funcAsDoOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Executes the provided actions depending on whether the outcome is success or failure.
        /// </summary>
        /// <param name="doOnSuccess">Action to execute if the outcome is a success.</param>
        /// <param name="doOnFailure">Action to execute if the outcome is a failure.</param>
        /// <returns>The original outcome after executing the actions.</returns>
        public Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure) => this switch
        {
            Right<F, S>(var r) => this.Do(doOnSuccess),
            Left<F, S>(var l) => l.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Executes the provided action if the outcome is a success.
        /// </summary>
        /// <param name="doOnSuccess">Action to execute if the outcome is a success.</param>
        /// <returns>The original outcome after executing the action.</returns>
        public Outcome<F, S> OnSuccess(Action<S> doOnSuccess) => this.Do(doOnSuccess);

        /// <summary>
        /// Executes the provided action if the outcome is a failure.
        /// </summary>
        /// <param name="doOnFailure">Action to execute if the outcome is a failure.</param>
        /// <returns>The original outcome after executing the action.</returns>
        public Outcome<F, S> OnFailure(Action<F> doOnFailure) => this switch
        {
            Right<F, S> s => s,
            Left<F, S>(var f) => f.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

    }
}
