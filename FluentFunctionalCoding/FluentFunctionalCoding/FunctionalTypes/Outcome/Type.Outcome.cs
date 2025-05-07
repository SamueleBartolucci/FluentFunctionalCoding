namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents the result of an operation that can be either a success (Right) or a failure (Left).
    /// </summary>
    /// <typeparam name="F">The type of the failure value.</typeparam>
    /// <typeparam name="S">The type of the success value.</typeparam>
    public abstract partial record Outcome<F, S>//  : Outcome<F, S>    
    {
        /// <summary>
        /// Throws a NotImplementedException for unknown outcome types.
        /// </summary>
        /// <returns>NotImplementedException</returns>
        internal static NotImplementedException UnknownOutcomeType() => new NotImplementedException($"Unknown type, expected: {nameof(Right<F, S>)} or {nameof(Left<F, S>)}");
               

        /// <summary>
        /// Gets a value indicating whether this outcome is a success.
        /// </summary>
        public abstract bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating whether this outcome is a failure.
        /// </summary>
        public bool IsFailure => !IsSuccess;
    }
}
