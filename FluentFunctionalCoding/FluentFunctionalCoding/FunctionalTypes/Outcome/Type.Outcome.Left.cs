namespace FluentFunctionalCoding
{
    sealed internal record Left<F, S> : Outcome<F, S>
    {
        internal F _failureValue;
        internal Left(F SuccessValue) => (_failureValue) = (SuccessValue);

        public override bool IsSuccess => false;

        internal void Deconstruct(out F value) => (value) = (_failureValue);
    }
}
