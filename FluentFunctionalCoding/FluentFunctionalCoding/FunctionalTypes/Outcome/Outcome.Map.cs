namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        /// <summary>
        /// Maps the outcome to new types for both success and failure cases.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="mapOnSuccess">Function to map the success value.</param>
        /// <param name="mapOnFailure">Function to map the failure value.</param>
        /// <returns>A new Outcome with mapped values.</returns>
        public Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S1>.Right(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F1, S1>.Left(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Maps the success value to a new type.
        /// </summary>
        /// <typeparam name="S1">The type of the new success value.</typeparam>
        /// <param name="mapOnSuccess">Function to map the success value.</param>
        /// <returns>A new Outcome with the mapped success value.</returns>
        public Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess) => this switch
        {
            Right<F, S>(var s) => Outcome<F, S1>.Right(mapOnSuccess(s)),
            Left<F, S>(var f) => Outcome<F, S1>.Left(f),
            _ => throw UnknownOutcomeType()
        };

        /// <summary>
        /// Maps the failure value to a new type.
        /// </summary>
        /// <typeparam name="F1">The type of the new failure value.</typeparam>
        /// <param name="mapOnFailure">Function to map the failure value.</param>
        /// <returns>A new Outcome with the mapped failure value.</returns>
        public Outcome<F1, S> MapFailure<F1>(Func<F, F1> mapOnFailure) => this switch
        {
            Right<F, S>(var s) => Outcome<F1, S>.Right(s),
            Left<F, S>(var f) => Outcome<F1, S>.Left(mapOnFailure(f)),
            _ => throw UnknownOutcomeType()
        };
    }
}
