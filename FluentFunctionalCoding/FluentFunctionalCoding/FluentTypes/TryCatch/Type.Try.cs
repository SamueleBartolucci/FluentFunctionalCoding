namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a computation that might fail with an exception.
    /// </summary>
    /// <typeparam name="TIn">The type of the input to the operation.</typeparam>
    /// <typeparam name="TOut">The type of the output if the operation succeeds.</typeparam>
    /// <typeparam name="TErr">The type of the error if the operation fails.</typeparam>
    /// <remarks>
    /// The Try monad provides a functional approach to exception handling.
    /// It encapsulates operations that might throw exceptions into a container 
    /// that either holds a successful result or the error information.
    /// This allows for composition of operations in a safe, fluent manner.
    /// </remarks>
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
        /// Gets a value indicating whether the Try operation was successful.
        /// </summary>
        public virtual bool IsSuccess => this switch
        {
            Success<TIn, TOut, TErr> success => true,
            _ => false
        };

        /// <summary>
        /// Gets a value indicating whether the Try operation failed.
        /// </summary>
        public bool IsFail => !IsSuccess;

        /// <summary>
        /// Protected constructor for Try base type.
        /// </summary>
        internal Try() { }

    }
}


