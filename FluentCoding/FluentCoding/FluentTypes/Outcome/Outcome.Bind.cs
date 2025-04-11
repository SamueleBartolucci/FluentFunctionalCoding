namespace FluentCoding
{

    public abstract partial record Outcome<F, S> : IOutcome<F, S>    
    {
        public IOutcome<F, S1> Bind<S1>(Func<S, IOutcome<F, S1>> bindOnSuccess) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => Outcome<F, S1>.Failure(f),
            _ => throw UnknownOutcomeType()
        };


        public IOutcome<F1, S> BindFailure<F1>(Func<F, IOutcome<F1, S>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Success(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };


        public IOutcome<F1, S1> BindFull<F1, S1>(Func<S, IOutcome<F1, S1>> bindOnSuccess, Func<F, IOutcome<F1, S1>> bindOnFailure) => this switch
        {
            Right<F, S>(var s) => bindOnSuccess(s),
            Left<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };
    }
}
