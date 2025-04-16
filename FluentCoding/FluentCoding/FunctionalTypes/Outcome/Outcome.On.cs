namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure) => this switch
        {
            Right<F, S>(var s) => this.Do(doOnSuccess),
            Left<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess) => this switch
        {
            Right<F, S>(var s) => this.Do(funcAsDoOnSuccess),
            Left<F, S> o => o,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure) => this switch
        {
            Right<F, S> s => s,
            Left<F, S>(var f) => f.Do(funcAsDoOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };



        public Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure) => this switch
        {
            Right<F, S>(var s) => this.Do(doOnSuccess),
            Left<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess(Action<S> doOnSuccess) => this switch
        {
            Right<F, S>(var s) => this.Do(_ => doOnSuccess(s)),
            Left<F, S> o => o,
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F, S> OnFailure(Action<F> doOnFailure) => this switch
        {
            Right<F, S> s => s,
            Left<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

    }
}
