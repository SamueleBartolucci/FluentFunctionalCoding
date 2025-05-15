namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Executes a function on the subject and returns a Try with a custom error type if an exception occurs, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <typeparam name="E">The type of the error.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="onCatchFunc">A function to convert an exception to the error type.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure.</returns>
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc, int numRetries = 1)
            => Prelude.Try(subject, funcToTry, onCatchFunc, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with a custom error type if an exception occurs, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="E">The type of the error.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="onCatchFunc">A function to convert an exception to the error type.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure.</returns>
        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc, int numRetries = 1)
          => Prelude.Try(subject, actionToTry, onCatchFunc, numRetries);

        /// <summary>
        /// Executes a function on the subject and returns a Try with Nothing as error type, invoking an action on exception, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="onCatchAction">An action to invoke if an exception occurs.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Nothing as error type.</returns>
        public static Try<S, R, Nothing> Try<S, R>(this S subject, Func<S, R> funcToTry, Action<S, Exception> onCatchAction, int numRetries = 1)
            => Prelude.Try(subject, funcToTry, onCatchAction, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Nothing as error type, invoking an action on exception, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="onCatchAction">An action to invoke if an exception occurs.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Nothing as error type.</returns>
        public static Try<S, Nothing, Nothing> Try<S>(this S subject, Action<S> actionToTry, Action<S, Exception> onCatchAction, int numRetries = 1)
          => Prelude.Try(subject, actionToTry, onCatchAction, numRetries);

        /// <summary>
        /// Executes a function on the subject and returns a Try with Exception as error type if an exception occurs, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Exception as error type.</returns>
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry, int numRetries = 1)
            => Prelude.Try(subject, funcToTry, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Exception as error type if an exception occurs, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Exception as error type.</returns>
        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry, int numRetries = 1)
            => Prelude.Try(subject, actionToTry, numRetries);
    }
}
