namespace FluentFunctionalCoding
{
    public abstract partial record Outcome<F, S>//  : Outcome<F, S>    
    {
        /// <summary>
        /// Creates a successful <see cref="Outcome{F, S}"/> instance containing the specified success value.
        /// </summary>
        /// <param name="successValue">The value to store as the success (Right) result.</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing a successful result.</returns>
        public static Outcome<F, S> Right(S successValue) => new Right<F, S>(successValue);

        /// <summary>
        /// Creates a failed <see cref="Outcome{F, S}"/> instance containing the specified failure value.
        /// </summary>
        /// <param name="failureValue">The value to store as the failure (Left) result.</param>
        /// <returns>An <see cref="Outcome{F, S}"/> representing a failure result.</returns>
        public static Outcome<F, S> Left(F failureValue) => new Left<F, S>(failureValue);
    }
}
