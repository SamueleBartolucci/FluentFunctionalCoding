namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents the result of a computation that may succeed or fail, capturing both the result and error information.
    /// </summary>
    /// <typeparam name="TIn">The input type for the computation.</typeparam>
    /// <typeparam name="TOut">The output type if the computation succeeds.</typeparam>
    /// <typeparam name="TErr">The error type if the computation fails.</typeparam>
    public abstract partial record Try<TIn, TOut, TErr>
    {
        /// <summary>
        /// Carries the exception thrown during the computation.
        /// </summary>
        internal static Exception CarryException(TIn subject, Exception e) => e;        

        /// <summary>
        /// Throws a NotImplementedException for unknown Try implementations.
        /// </summary>
        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(Success<TIn, TOut, TErr>)} or {nameof(Failure<TIn, TOut, TErr>)}");

        /// <summary>
        /// Gets a value indicating whether the computation was successful.
        /// </summary>
        public virtual bool IsSuccess => this switch
        {
            Success<TIn, TOut, TErr> success => true,
            _ => false
        };

        /// <summary>
        /// Gets a value indicating whether the computation failed.
        /// </summary>
        public bool IsFail => !IsSuccess;

        /// <summary>
        /// Protected constructor for Try base type.
        /// </summary>
        internal Try() { }

    }
}


