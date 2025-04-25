namespace FluentFunctionalCoding
{
    public abstract partial record Try<S, R, E>
    {
        public static Try<S, R, E> Wrap(S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
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

        public static Try<S, R, Exception> Wrap(S subject, Func<S, R> funcToTry)
             => Try<S, R, Exception>.Wrap(subject, funcToTry, CarryException);

        public static Try<S, Nothing, Exception> Wrap(S subject, Action<S> actionToTry)
             => Try<S, Nothing, Exception>.Wrap(subject, actionToTry.AsFunc(), CarryException);

        public static Try<S, Nothing, E> Wrap(S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
             => Try<S, Nothing, E>.Wrap(subject, actionToTry.AsFunc(), onCatchFunc);

        public static Try<S, Nothing, Nothing> Wrap(S subject, Action<S> actionToTry, Action<S, Exception> onCatch)
            => Try<S, Nothing, Nothing>.Wrap(subject, actionToTry.AsFunc(), onCatch.AsFunc());

        public static Try<S, R, Nothing> Wraps(S subject, Func<S, R> funcToTry, Action<S, Exception> onCatch)
            => Try<S, R, Nothing>.Wrap(subject, funcToTry, onCatch.AsFunc());



    }
}


