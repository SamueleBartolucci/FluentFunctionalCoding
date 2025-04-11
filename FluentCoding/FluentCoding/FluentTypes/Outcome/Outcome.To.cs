namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public IOptional<S> ToOptional() => this switch
        {
            Right<F, S>(var s) => Optional<S>.Some(s),
            _ => Optional<S>.None()
        };

        public IOptional<F> ToOptionalFailure() => this switch
        {
            Left<F, S>(var f) => Optional<F>.Some(f),
            _ => Optional<F>.None(),
        };
    }
}
