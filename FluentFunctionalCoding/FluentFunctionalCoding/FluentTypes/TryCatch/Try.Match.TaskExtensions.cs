namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {

        /// <summary>
        /// Asynchronously matches a failed result of a <see cref="Try{TIn, TOut, TErr}"/> task and applies the specified error handler.
        /// </summary>
        /// <typeparam name="TIn">The type of the input value.</typeparam>
        /// <typeparam name="TOut">The type of the output value.</typeparam>
        /// <typeparam name="TErr">The type of the error value.</typeparam>
        /// <param name="tried">The task containing the <see cref="Try{TIn, TOut, TErr}"/> instance.</param>
        /// <param name="onError">A function to handle the error value.</param>
        /// <returns>A task containing the result of the error handler.</returns>
        public static async Task<TOut> MatchFailAsync<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Func<TErr, TOut> onError)
             => (await tried).MatchFail(onError);

        /// <summary>
        /// Asynchronously matches a failed result of a <see cref="Try{TIn, TOut, TErr}"/> task and returns a specified value on failure.
        /// </summary>
        /// <typeparam name="TIn">The type of the input value.</typeparam>
        /// <typeparam name="TOut">The type of the output value.</typeparam>
        /// <typeparam name="TErr">The type of the error value.</typeparam>
        /// <param name="tried">The task containing the <see cref="Try{TIn, TOut, TErr}"/> instance.</param>
        /// <param name="valueOnFail">The value to return on failure.</param>
        /// <returns>A task containing the specified value on failure.</returns>
        public static async Task<TOut> MatchFailAsync<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, TOut valueOnFail)
            => (await tried).MatchFail(valueOnFail);

        /// <summary>
        /// Asynchronously matches a <see cref="Try{TIn, TOut, TErr}"/> task and applies the specified success and error handlers.
        /// </summary>
        /// <typeparam name="TIn">The type of the input value.</typeparam>
        /// <typeparam name="TOut">The type of the output value.</typeparam>
        /// <typeparam name="TErr">The type of the error value.</typeparam>
        /// <typeparam name="M">The type of the result produced by the handlers.</typeparam>
        /// <param name="tried">The task containing the <see cref="Try{TIn, TOut, TErr}"/> instance.</param>
        /// <param name="onSuccess">A function to handle the success value.</param>
        /// <param name="onError">A function to handle the error value.</param>
        /// <returns>A task containing the result of the appropriate handler.</returns>
        public static async Task<M> MatchAsync<TIn, TOut, TErr, M>(this Task<Try<TIn, TOut, TErr>> tried, Func<TOut, M> onSuccess, Func<TErr, M> onError)
            => (await tried).Match(onSuccess, onError);
    }
}
