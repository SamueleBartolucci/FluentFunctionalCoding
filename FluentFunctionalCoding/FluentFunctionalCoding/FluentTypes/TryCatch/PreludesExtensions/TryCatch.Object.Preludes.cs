namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Executes a function on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => Prelude.Try(subject, funcToTry, onCatchFunc);

        /// <summary>
        /// Executes an action on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
          => Prelude.Try(subject, actionToTry, onCatchFunc);

        /// <summary>
        /// Executes a function on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        public static Try<S, R, Nothing> Try<S, R>(this S subject, Func<S, R> funcToTry, Action<S, Exception> onCatchAction)
            => Prelude.Try(subject, funcToTry, onCatchAction);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        public static Try<S, Nothing, Nothing> Try<S>(this S subject, Action<S> actionToTry, Action<S, Exception> onCatchAction)
          => Prelude.Try(subject, actionToTry, onCatchAction);

        /// <summary>
        /// Executes a function on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry)
            => Prelude.Try(subject, funcToTry);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry)
            => Prelude.Try(subject, actionToTry);
    }
}
