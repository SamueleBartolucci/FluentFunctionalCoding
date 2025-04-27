
namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {

        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => FluentFunctionalCoding.Try<S, R, E>.Wrap(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
          => FluentFunctionalCoding.Try<S, Nothing, E>.Wrap(subject, actionToTry, onCatchFunc);

        public static Try<S, R, Nothing> Try<S, R>(this S subject, Func<S, R> funcToTry, Action<S, Exception> onCatchAction)
            => FluentFunctionalCoding.Try<S, R, Nothing>.Wrap(subject, funcToTry, onCatchAction);

        public static Try<S, Nothing, Nothing> Try<S>(this S subject, Action<S> actionToTry, Action<S, Exception> onCatchAction)
          => FluentFunctionalCoding.Try<S, Nothing, Nothing>.Wrap(subject, actionToTry, onCatchAction);



        //TRY with CATCH EX 
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry)
            => FluentFunctionalCoding.Try<S, R, Exception>.Wrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry)
            => FluentFunctionalCoding.Try<S, Nothing, Exception>.Wrap(subject, actionToTry);

    }


}
