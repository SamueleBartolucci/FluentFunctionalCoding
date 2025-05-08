namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a successful Try operation.
    /// </summary>
    /// <typeparam name="TIn">The input type that was used in the operation.</typeparam>
    /// <typeparam name="TOut">The output type resulting from the successful operation.</typeparam>
    /// <typeparam name="TErr">The error type that would be used if the operation failed.</typeparam>
    /// <remarks>
    /// This class is part of the Try monad implementation, representing operations that completed successfully.
    /// It contains both the original input subject and the successful result value.
    /// </remarks>
    internal sealed record Success<TIn, TOut, TErr> : Try<TIn, TOut, TErr>
    {
        internal TIn _subject;
        internal TOut _result;

        /// <summary>
        /// Initializes a new instance of the <see cref="Success{TIn, TOut, TErr}"/> class.
        /// </summary>
        /// <param name="subject">The original input to the operation.</param>
        /// <param name="result">The successful result of the operation.</param>
        internal Success(TIn subject, TOut result) : base() => (_subject, _result) = (subject, result);

        /// <summary>
        /// Gets a value indicating whether the Try operation was successful.
        /// </summary>
        /// <remarks>
        /// For Success instances, this always returns true.
        /// </remarks>
        public override bool IsSuccess => true;

        /// <summary>
        /// Deconstructs this instance into its component parts.
        /// </summary>
        /// <param name="subject">The original input to the operation.</param>
        /// <param name="result">The successful result of the operation.</param>
        internal void Deconstruct(out TIn subject, out TOut result) => (subject, result) = (_subject, _result);
    }
}
