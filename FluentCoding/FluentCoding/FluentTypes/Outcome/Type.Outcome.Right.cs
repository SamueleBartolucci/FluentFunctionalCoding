namespace FluentCoding
{
    internal record Right<F, S> : Outcome<F, S>
    {
        internal S _successValue;
        internal Right(S SuccessValue) => (_successValue) = (SuccessValue);

        internal void Deconstruct(out S value) => (value) = (_successValue);
    }
}
