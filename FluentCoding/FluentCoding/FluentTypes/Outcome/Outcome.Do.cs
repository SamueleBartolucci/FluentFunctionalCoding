namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject) => this switch
        {
            Right<F, S>(var s) => s.Do(actionsToApplyOnSuccessSubject).Map(Success),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsactionsToApplyOnSuccessSubject) => this switch
        {
            Right<F, S>(var s) => s.Do(funcsAsactionsToApplyOnSuccessSubject).Map(Success),
            Left<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

    }
}
