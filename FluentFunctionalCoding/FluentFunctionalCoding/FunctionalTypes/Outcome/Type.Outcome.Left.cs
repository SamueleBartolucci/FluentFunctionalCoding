namespace FluentFunctionalCoding
{
    sealed internal record Left<F, S> : Outcome<F, S>
    {
        /// <summary>
        /// The failure value contained in this Left outcome.
        /// </summary>
        internal F _failureValue;
        /// <summary>
        /// Initializes a new instance of the <see cref="Left{F, S}"/> record with the specified failure value.
        /// </summary>
        /// <param name="SuccessValue">The failure value to store.</param>
        internal Left(F SuccessValue) => (_failureValue) = (SuccessValue);

        /// <inheritdoc/>
        public override bool IsSuccess => false;

        /// <summary>
        /// Deconstructs this Left outcome to its failure value.
        /// </summary>
        /// <param name="value">The failure value.</param>
        internal void Deconstruct(out F value) => (value) = (_failureValue);
    }
}
