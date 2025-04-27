namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var s) => s.Do(actionsToApplyOnSuccess).Map(Success),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsActionsToApplyOnSuccess) => this switch
        {
            Right<F, S>(var s) => s.Do(funcsAsActionsToApplyOnSuccess).Map(Success),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

    }
}
