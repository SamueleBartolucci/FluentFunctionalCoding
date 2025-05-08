namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a failed Try operation.
    /// </summary>
    /// <typeparam name="TIn">The input type that was used in the operation.</typeparam>
    /// <typeparam name="TOut">The output type that would have resulted from a successful operation.</typeparam>
    /// <typeparam name="TErr">The error type resulting from the failed operation.</typeparam>
    /// <remarks>
    /// This class is part of the Try monad implementation, representing operations that failed.
    /// It contains the original input subject, the error result, and the exception that occurred.
    /// </remarks>
    internal sealed record Failure<TIn, TOut, TErr> : Try<TIn, TOut, TErr>
    {
        /// <summary>
        /// The original input to the operation.
        /// </summary>
        internal TIn _subject;
        
        /// <summary>
        /// The error result of the failed operation.
        /// </summary>
        internal TErr _errorResult;
        
        /// <summary>
        /// The exception that caused the operation to fail.
        /// </summary>
        internal Exception _Error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Failure{TIn, TOut, TErr}"/> class.
        /// </summary>
        /// <param name="subject">The original input to the operation.</param>
        /// <param name="errorResult">The error result of the failed operation.</param>
        /// <param name="ex">The exception that caused the operation to fail.</param>
        internal Failure(TIn subject, TErr errorResult, Exception ex) : base() => (_subject, _errorResult, _Error) = (subject, errorResult, ex);

        /// <summary>
        /// Gets a value indicating whether the Try operation was successful.
        /// </summary>
        /// <remarks>
        /// For Failure instances, this always returns false.
        /// </remarks>
        public override bool IsSuccess => false;

        /// <summary>
        /// Deconstructs this instance into its component parts.
        /// </summary>
        /// <param name="subject">The original input to the operation.</param>
        /// <param name="result">The error result of the failed operation.</param>
        /// <param name="ex">The exception that caused the operation to fail.</param>
        internal void Deconstruct(out TIn subject, out TErr result, out Exception ex) => (subject, result, ex) = (_subject, _errorResult, _Error);
    }
}
