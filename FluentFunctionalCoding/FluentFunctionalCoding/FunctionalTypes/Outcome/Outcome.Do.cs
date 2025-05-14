namespace FluentFunctionalCoding
{
    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Applies one or more actions to the success value (Right) of this <see cref="Outcome{F, S}"/>, if present, and returns the original <see cref="Outcome{F, S}"/> for fluent chaining.
        /// </summary>
        /// <param name="actionsToApplyOnSuccess">Actions to apply to the success value if this is a Right outcome.</param>
        /// <returns>The original <see cref="Outcome{F, S}"/> instance.</returns>
        public Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var rValue) => rValue.Do(actionsToApplyOnSuccess).Map(Right),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Applies one or more functions to the success value (Right) of this <see cref="Outcome{F, S}"/>, if present, discarding their results, and returns the original <see cref="Outcome{F, S}"/> for fluent chaining.
        /// </summary>
        /// <typeparam name="T">The return type of the functions (results are ignored).</typeparam>
        /// <param name="funcsAsActionsToApplyOnSuccess">Functions to apply to the success value if this is a Right outcome.</param>
        /// <returns>The original <see cref="Outcome{F, S}"/> instance.</returns>
        public Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var rValue) => rValue.Do(funcsAsActionsToApplyOnSuccess).Map(Right),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };
    }
}
