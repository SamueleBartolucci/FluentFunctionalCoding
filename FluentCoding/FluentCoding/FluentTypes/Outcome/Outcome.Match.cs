namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure) => this switch
        {
            Right<F, S>(var s) => onSuccess(s),
            Left<F, S>(var f) => onFailure(f),
            _ => throw UnknownOutcomeType()
        };

        public M Match<M>(Func<S, M> onSuccess, M valueOnFailure) => this switch
        {
            Right<F, S>(var s) => onSuccess(s),
            Left<F, S>(_) => valueOnFailure,
            _ => throw UnknownOutcomeType()
        };
    }
}
