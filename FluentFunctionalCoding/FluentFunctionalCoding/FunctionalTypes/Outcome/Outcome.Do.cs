namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var rValue) => rValue.Do(actionsToApplyOnSuccess).Map(Right),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var rValue) => rValue.Do(funcsAsActionsToApplyOnSuccess).Map(Right),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

    }
}
