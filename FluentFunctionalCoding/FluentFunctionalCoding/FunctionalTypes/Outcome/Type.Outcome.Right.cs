namespace FluentFunctionalCoding
{
    sealed internal record Right<F, S> : Outcome<F, S>
    {
        /// <summary>
        /// The success value contained in this Right outcome.
        /// </summary>
        internal S _successValue;
        /// <summary>
        /// Initializes a new instance of the <see cref="Right{F, S}"/> record with the specified success value.
        /// </summary>
        /// <param name="SuccessValue">The success value to store.</param>
        internal Right(S SuccessValue) => (_successValue) = (SuccessValue);

        /// <inheritdoc/>
        public override bool IsSuccess => true;
        /// <summary>
        /// Deconstructs this Right outcome to its success value.
        /// </summary>
        /// <param name="value">The success value.</param>
        internal void Deconstruct(out S value) => (value) = (_successValue);
    }
}
