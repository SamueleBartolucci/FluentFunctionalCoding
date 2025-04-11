namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public IOutcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S1>.Success(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F1, S1>.Failure(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };


        public IOutcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess) => this switch
        {
            Right<F, S>(var s) => Outcome<F, S1>.Success(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F, S1>.Failure(f),
            _ => throw UnknownOutcomeType()
        };


        public IOutcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Success(s),
            Left<F, S>(var f) => Outcome<F1, S>.Failure(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };
    }
}
