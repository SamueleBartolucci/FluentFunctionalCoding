namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S1>.Right(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F1, S1>.Left(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess) => this switch
        {
            Right<F, S>(var s) => Outcome<F, S1>.Right(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F, S1>.Left(f),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Right(s),
            Left<F, S>(var f) => Outcome<F1, S>.Left(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };
    }
}
