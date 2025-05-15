namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides static methods to create Try monads for exception handling in a functional style.
    /// </summary>
    public static partial class Prelude
    {
        /// <summary>
        /// Returns the exception to be carried as the error value.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="subject">The subject value (unused).</param>
        /// <param name="e">The exception to carry.</param>
        /// <returns>The provided exception.</returns>
        internal static Exception CarryException<S>(S subject, Exception e) => e;

        /// <summary>
        /// Executes a function on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <typeparam name="E">The type of the error.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="onCatchFunc">A function to convert an exception to the error type.</param>
        /// <returns>A Try representing either success or failure.</returns>
        private static Try<S, R, E> _Try<S, R, E>(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
        {
            try
            {
                return new Success<S, R, E>(subject, funcToTry(subject));
            }
            catch (Exception e)
            {
                return new Failure<S, R, E>(subject, onCatchFunc(subject, e), e);
            }
        }

        /// <summary>
        /// Executes a function on the subject and retries up to <paramref name="numRetries"/> times if an exception occurs, returning a Try with a custom error type.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <typeparam name="E">The type of the error.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="onCatchFunc">A function to convert an exception to the error type.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>
        /// A <see cref="Try{S, R, E}"/> representing either success or failure after retries.
        /// If all retries fail, the last failure is returned.
        /// </returns>
        /// <remarks>
        /// If all retries fail, the last failure is returned. The default value for <paramref name="numRetries"/> is 1 (no retry).
        /// </remarks>
        public static Try<S, R, E> Try<S, R, E>(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc, int numRetries = 1)
        {
            int execution = 0;

            Try<S, R, E> tryResult = null;
            do
            {
                execution++;
                tryResult = Prelude._Try(subject, funcToTry, onCatchFunc);

                if (tryResult is Success<S, R, E> || execution == numRetries)
                    break;

            } while (execution <= numRetries);

            return tryResult!;
        }

        /// <summary>
        /// Executes a function on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Exception as error type.</returns>
        public static Try<S, R, Exception> Try<S, R>(S subject, Func<S, R> funcToTry, int numRetries = 1)
             => Prelude.Try(subject, funcToTry, CarryException, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Exception as error type.</returns>
        public static Try<S, Nothing, Exception> Try<S>(S subject, Action<S> actionToTry, int numRetries = 1)
             => Prelude.Try(subject, actionToTry.AsFunc(), CarryException, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="E">The type of the error.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="onCatchFunc">A function to convert an exception to the error type.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure.</returns>
        public static Try<S, Nothing, E> Try<S,E>(S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc, int numRetries = 1)
             => Prelude.Try(subject, actionToTry.AsFunc(), onCatchFunc, numRetries);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="onCatch">An action to invoke if an exception occurs.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Nothing as error type.</returns>
        public static Try<S, Nothing, Nothing> Try<S>(S subject, Action<S> actionToTry, Action<S, Exception> onCatch, int numRetries = 1)
            => Prelude.Try(subject, actionToTry.AsFunc(), onCatch.AsFunc(), numRetries);

        /// <summary>
        /// Executes a function on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The type of the result.</typeparam>
        /// <param name="subject">The subject value.</param>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="onCatch">An action to invoke if an exception occurs.</param>
        /// <param name="numRetries">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try representing either success or failure with Nothing as error type.</returns>
        public static Try<S, R, Nothing> Try<S, R>(S subject, Func<S, R> funcToTry, Action<S, Exception> onCatch, int numRetries = 1)
            => Prelude.Try(subject, funcToTry, onCatch.AsFunc(), numRetries);
    }
}


