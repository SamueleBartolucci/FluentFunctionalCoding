namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Executes a function with the specified subject and handles exceptions using a custom catch function, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The return type of the function.</typeparam>
        /// <typeparam name="E">The type of the exception result.</typeparam>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="subject">The subject to pass to the function.</param>
        /// <param name="onCatchFunc">A function to handle exceptions, receiving the subject and exception.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, R, E> Try<S, R, E>(this Func<S, R> funcToTry, S subject, Func<S, Exception, E> onCatchFunc, int numRetry = 1)
            => Prelude.Try(subject, funcToTry, onCatchFunc, numRetry);

        /// <summary>
        /// Executes a function with the specified subject and handles exceptions using a custom catch action, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The return type of the function.</typeparam>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="subject">The subject to pass to the function.</param>
        /// <param name="onCatchAction">An action to handle exceptions, receiving the subject and exception.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, R, Nothing> Try<S, R>(this Func<S, R> funcToTry, S subject, Action<S, Exception> onCatchAction, int numRetry = 1)
            => Prelude.Try(subject, funcToTry, onCatchAction, numRetry);

        /// <summary>
        /// Executes an action with the specified subject and handles exceptions using a custom catch function, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="E">The type of the exception result.</typeparam>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="subject">The subject to pass to the action.</param>
        /// <param name="onCatchFunc">A function to handle exceptions, receiving the subject and exception.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, Nothing, E> Try<S, E>(this Action<S> actionToTry, S subject, Func<S, Exception, E> onCatchFunc, int numRetry = 1)
          => Prelude.Try(subject, actionToTry, onCatchFunc, numRetry);

        /// <summary>
        /// Executes an action with the specified subject and handles exceptions using a custom catch action, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="subject">The subject to pass to the action.</param>
        /// <param name="onCatchAction">An action to handle exceptions, receiving the subject and exception.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, Nothing, Nothing> Try<S>(this Action<S> actionToTry, S subject, Action<S, Exception> onCatchAction, int numRetry = 1)
          => Prelude.Try(subject, actionToTry, onCatchAction, numRetry);

        /// <summary>
        /// Executes a function with the specified subject and catches exceptions of type <see cref="Exception"/>, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <typeparam name="R">The return type of the function.</typeparam>
        /// <param name="funcToTry">The function to execute.</param>
        /// <param name="subject">The subject to pass to the function.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, R, Exception> Try<S, R>(this Func<S, R> funcToTry, S subject, int numRetry = 1)
            => Prelude.Try(subject, funcToTry, numRetry);

        /// <summary>
        /// Executes an action with the specified subject and catches exceptions of type <see cref="Exception"/>, with optional retries.
        /// </summary>
        /// <typeparam name="S">The type of the subject.</typeparam>
        /// <param name="actionToTry">The action to execute.</param>
        /// <param name="subject">The subject to pass to the action.</param>
        /// <param name="numRetry">The number of times to retry on failure (default is 1).</param>
        /// <returns>A Try instance representing the result or exception.</returns>
        public static Try<S, Nothing, Exception> Try<S>(this Action<S> actionToTry, S subject, int numRetry = 1)
            => Prelude.Try(subject, actionToTry, numRetry);

        ///// <summary>
        ///// Executes an action and catches exceptions of type <see cref="Exception"/>.
        ///// </summary>
        ///// <param name="subjectAction">The action to execute.</param>
        ///// <returns>A Try instance representing the result or exception.</returns>
        //public static Try<Nothing, Nothing, Exception> Try(this Action subjectAction)
        //    => Prelude.Try(Nothing.SoftNull, s => subjectAction());

    }
}
