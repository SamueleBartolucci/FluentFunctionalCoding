namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>//  : Outcome<F, S>
    {
        public Outcome<F, S1> Bind<S1>(Func<S, Outcome<F, S1>> bindOnSuccess) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => Outcome<F, S1>.Failure(f),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F1, S> BindFailure<F1>(Func<F, Outcome<F1, S>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Success(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };
    }
}
