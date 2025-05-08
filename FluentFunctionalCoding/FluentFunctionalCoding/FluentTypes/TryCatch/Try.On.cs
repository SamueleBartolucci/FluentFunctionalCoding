namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        /// <summary>
        /// Executes the specified action when the Try operation is in a failure state.
        /// </summary>
        /// <param name="actionOnError">The action to execute with both the input subject and error result.</param>
        /// <returns>The current Try instance, allowing for method chaining.</returns>
        /// <remarks>
        /// This method enables side effects when an operation fails without altering the Try flow.
        /// Useful for logging, error reporting, or monitoring failure cases.
        /// </remarks>
        public Try<TIn, TOut, TErr> OnFail(Action<TIn, TErr> actionOnError)
        {
            if (this is Failure<TIn, TOut, TErr>(var s, var e, _))
                actionOnError(s, e);

            return this;
        }

        /// <summary>
        /// Executes the specified action on the subject when the Try operation is in a failure state.
        /// </summary>
        /// <param name="doOnsubjectWhenOnError">The action to execute with the input subject.</param>
        /// <returns>The current Try instance, allowing for method chaining.</returns>
        /// <remarks>
        /// This overload is useful when you only need to perform an action on the input subject
        /// and don't need access to the error information.
        /// </remarks>
        public Try<TIn, TOut, TErr> OnFail(Action<TIn> doOnsubjectWhenOnError)
        {
            if (this is Failure<TIn, TOut, TErr>(var s, _, _))
                doOnsubjectWhenOnError(s);

            return this;
        }


        /// <summary>
        /// Executes the specified action when the Try operation is in a success state.
        /// </summary>
        /// <param name="actionOnSuccess">The action to execute with both the input subject and result.</param>
        /// <returns>The current Try instance, allowing for method chaining.</returns>
        /// <remarks>
        /// This method enables side effects when an operation succeeds without altering the Try flow.
        /// Useful for logging, notifications, or further processing in a fluent chain.
        /// </remarks>
        public Try<TIn, TOut, TErr> OnSuccess(Action<TIn, TOut> actionOnSuccess)
        {
            if (this is Success<TIn, TOut, TErr>(var s, var r))
                actionOnSuccess(s, r);

            return this;
        }

        /// <summary>
        /// Executes the specified action on the result when the Try operation is in a success state.
        /// </summary>
        /// <param name="doOnResultWhenOnSuccess">The action to execute with the successful result.</param>
        /// <returns>The current Try instance, allowing for method chaining.</returns>
        /// <remarks>
        /// This overload is useful when you only need to perform an action on the successful result
        /// and don't need access to the original input subject.
        /// </remarks>
        public Try<TIn, TOut, TErr> OnSuccess(Action<TOut> doOnResultWhenOnSuccess)
        {
            if (this is Success<TIn, TOut, TErr>(_, var r))
                doOnResultWhenOnSuccess(r);

            return this;
        }

    }
}
