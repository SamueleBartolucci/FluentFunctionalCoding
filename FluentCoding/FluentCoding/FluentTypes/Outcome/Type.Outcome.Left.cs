namespace FluentCoding
{
    sealed internal record Left<F, S> : Outcome<F, S>
    {
        internal F _failureValue;
        internal Left(F SuccessValue) => (_failureValue) = (SuccessValue);

        internal void Deconstruct(out F value) => (value) = (_failureValue);
    }
}
