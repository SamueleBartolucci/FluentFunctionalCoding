namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure) => this switch
        {
            Right<F, S> r => r.Do(doOnSuccess),
            Left<F, S>(var l) => l.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess) => this switch
        {
            Right<F, S> r => r.Do(funcAsDoOnSuccess),
            Left<F, S> l => l,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure) => this switch
        {
            Right<F, S> r => r,
            Left<F, S>(var l) => l.Do(funcAsDoOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };



        public Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure) => this switch
        {
            Right<F, S>(var r) => this.Do(doOnSuccess),
            Left<F, S>(var l) => l.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess(Action<S> doOnSuccess) => this.Do(doOnSuccess);
        //    this switch
        //{
        //    Right<F, S>(var r) => this.Do(doOnSuccess),//this.Do(_ => doOnSuccess(r)),
        //    Left<F, S> o => o,
        //    _ => throw UnknownOutcomeType()
        //};


        public Outcome<F, S> OnFailure(Action<F> doOnFailure) => this switch
        {
            Right<F, S> s => s,
            Left<F, S>(var f) => f.Do(doOnFailure).Map(Left),
            _ => throw UnknownOutcomeType()
        };

    }
}
