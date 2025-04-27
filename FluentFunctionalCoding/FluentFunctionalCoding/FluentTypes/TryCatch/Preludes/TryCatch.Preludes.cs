namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        internal static Exception CarryException<S>(S subject, Exception e) => e;

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

        public static Try<S, R, Exception> Try<S, R>(S subject, Func<S, R> funcToTry)
             => Prelude.Try(subject, funcToTry, CarryException);

        public static Try<S, Nothing, Exception> Try<S>(S subject, Action<S> actionToTry)
             => Prelude.Try(subject, actionToTry.AsFunc(), CarryException);

        public static Try<S, Nothing, E> Try<S,E>(S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
             => Prelude.Try(subject, actionToTry.AsFunc(), onCatchFunc);

        public static Try<S, Nothing, Nothing> Try<S>(S subject, Action<S> actionToTry, Action<S, Exception> onCatch)
            => Prelude.Try(subject, actionToTry.AsFunc(), onCatch.AsFunc());

        public static Try<S, R, Nothing> Try<S, R>(S subject, Func<S, R> funcToTry, Action<S, Exception> onCatch)
            => Prelude.Try(subject, funcToTry, onCatch.AsFunc());
    }
}


