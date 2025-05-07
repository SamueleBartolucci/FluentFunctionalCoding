namespace FluentFunctionalCoding
{
    /// <summary>
    /// Contains extension methods for handling tasks with Try functional types.
    /// </summary>
    public static partial class TryExtension
    {
        /// <summary>
        /// Executes an action if the operation fails.
        /// </summary>
        /// <typeparam name="TIn">The input type of the Try functional type.</typeparam>
        /// <typeparam name="TOut">The output type of the Try functional type.</typeparam>
        /// <typeparam name="TErr">The error type of the Try functional type.</typeparam>
        /// <param name="tried">The task representing the Try functional type.</param>
        /// <param name="actionOnError">The action to execute when the operation fails.</param>
        /// <returns>A task that represents the Try functional type after the action is executed.</returns>
        public static async Task<Try<TIn, TOut, TErr>> OnFail<TIn, TOut, TErr>(
            this Task<Try<TIn, TOut, TErr>> tried,
            Action<TIn, TErr> actionOnError)
            => (await tried).OnFail(actionOnError);

        /// <summary>
        /// Executes an action with the input value if the operation fails.
        /// </summary>
        /// <typeparam name="TIn">The input type of the Try functional type.</typeparam>
        /// <typeparam name="TOut">The output type of the Try functional type.</typeparam>
        /// <typeparam name="TErr">The error type of the Try functional type.</typeparam>
        /// <param name="tried">The task representing the Try functional type.</param>
        /// <param name="doOnsubjectWhenOnError">The action to execute using the input value when the operation fails.</param>
        /// <returns>A task that represents the Try functional type after the action is executed.</returns>
        public static async Task<Try<TIn, TOut, TErr>> OnFail<TIn, TOut, TErr>(
            this Task<Try<TIn, TOut, TErr>> tried,
            Action<TIn> doOnsubjectWhenOnError)
            => (await tried).OnFail(doOnsubjectWhenOnError);

        /// <summary>
        /// Executes an action if the operation succeeds.
        /// </summary>
        /// <typeparam name="TIn">The input type of the Try functional type.</typeparam>
        /// <typeparam name="TOut">The output type of the Try functional type.</typeparam>
        /// <typeparam name="TErr">The error type of the Try functional type.</typeparam>
        /// <param name="tried">The task representing the Try functional type.</param>
        /// <param name="actionOnSuccess">The action to execute when the operation succeeds.</param>
        /// <returns>A task that represents the Try functional type after the action is executed.</returns>
        public static async Task<Try<TIn, TOut, TErr>> OnSuccess<TIn, TOut, TErr>(
            this Task<Try<TIn, TOut, TErr>> tried,
            Action<TIn, TOut> actionOnSuccess)
            => (await tried).OnSuccess(actionOnSuccess);

        /// <summary>
        /// Executes an action with the output value if the operation succeeds.
        /// </summary>
        /// <typeparam name="TIn">The input type of the Try functional type.</typeparam>
        /// <typeparam name="TOut">The output type of the Try functional type.</typeparam>
        /// <typeparam name="TErr">The error type of the Try functional type.</typeparam>
        /// <param name="tried">The task representing the Try functional type.</param>
        /// <param name="doOnResultWhenOnSuccess">The action to execute using the output value when the operation succeeds.</param>
        /// <returns>A task that represents the Try functional type after the action is executed.</returns>
        public static async Task<Try<TIn, TOut, TErr>> OnSuccess<TIn, TOut, TErr>(
            this Task<Try<TIn, TOut, TErr>> tried,
            Action<TOut> doOnResultWhenOnSuccess)
            => (await tried).OnSuccess(doOnResultWhenOnSuccess);
    }
}
