namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides static methods to create Try monads for exception handling in a functional style.
    /// </summary>
    public static partial class Prelude
    {
        internal static Exception CarryException<S>(S subject, Exception e) => e;

        /// <summary>
        /// Executes a function on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        public static Try<S, R, E> Try<S, R, E>(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
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
        /// Executes a function on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        public static Try<S, R, Exception> Try<S, R>(S subject, Func<S, R> funcToTry)
             => Prelude.Try(subject, funcToTry, CarryException);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Exception as error type if an exception occurs.
        /// </summary>
        public static Try<S, Nothing, Exception> Try<S>(S subject, Action<S> actionToTry)
             => Prelude.Try(subject, actionToTry.AsFunc(), CarryException);

        /// <summary>
        /// Executes an action on the subject and returns a Try with a custom error type if an exception occurs.
        /// </summary>
        public static Try<S, Nothing, E> Try<S,E>(S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
             => Prelude.Try(subject, actionToTry.AsFunc(), onCatchFunc);

        /// <summary>
        /// Executes an action on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        public static Try<S, Nothing, Nothing> Try<S>(S subject, Action<S> actionToTry, Action<S, Exception> onCatch)
            => Prelude.Try(subject, actionToTry.AsFunc(), onCatch.AsFunc());

        /// <summary>
        /// Executes a function on the subject and returns a Try with Nothing as error type, invoking an action on exception.
        /// </summary>
        public static Try<S, R, Nothing> Try<S, R>(S subject, Func<S, R> funcToTry, Action<S, Exception> onCatch)
            => Prelude.Try(subject, funcToTry, onCatch.AsFunc());
    }
}


