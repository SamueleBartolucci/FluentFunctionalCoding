namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        /// <summary>
        /// Returns the result if successful, otherwise invokes the provided function with the error.
        /// </summary>
        /// <param name="onError">Function to handle the error case.</param>
        /// <returns>The result or the value returned by <paramref name="onError"/>.</returns>
        public TOut MatchFail(Func<TErr, TOut> onError)
             => this switch
             {
                 Success<TIn, TOut, TErr>(_, var r) => r,
                 Failure<TIn, TOut, TErr>(_, var e, _) => onError(e),
                 _ => throw UnknowImplementation()
             };

        /// <summary>
        /// Returns the result if successful, otherwise returns the provided value.
        /// </summary>
        /// <param name="valueOnFail">Value to return if the computation failed.</param>
        /// <returns>The result or <paramref name="valueOnFail"/>.</returns>
        public TOut MatchFail(TOut valueOnFail)
             => this switch
             {
                 Success<TIn, TOut, TErr>(_, var r) => r,
                 Failure<TIn, TOut, TErr>(var s, _, _) => valueOnFail,
                 _ => throw UnknowImplementation()
             };

        /// <summary>
        /// Pattern matches on the Try, invoking the appropriate function for success or error.
        /// </summary>
        /// <typeparam name="M">The return type of the match functions.</typeparam>
        /// <param name="onSuccess">Function to handle the success case.</param>
        /// <param name="onError">Function to handle the error case.</param>
        /// <returns>The result of the invoked function.</returns>
        public M Match<M>(Func<TOut, M> onSuccess, Func<TErr, M> onError)
           => this switch
           {
               Success<TIn, TOut, TErr>(_, var r) => onSuccess(r),
               Failure<TIn, TOut, TErr>(_, var e, _) => onError(e),
               _ => throw UnknowImplementation()
           };
    }
}
