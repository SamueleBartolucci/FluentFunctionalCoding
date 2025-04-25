namespace FluentFunctionalCoding
{
    sealed internal record Right<F, S> : Outcome<F, S>
    {
        internal S _successValue;
        internal Right(S SuccessValue) => (_successValue) = (SuccessValue);

        public override bool IsSuccess => true;
        internal void Deconstruct(out S value) => (value) = (_successValue);
    }
}
