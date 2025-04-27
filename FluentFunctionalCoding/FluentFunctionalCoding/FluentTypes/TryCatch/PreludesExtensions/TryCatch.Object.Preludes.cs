
namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {

        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => Prelude.Try(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
          => Prelude.Try(subject, actionToTry, onCatchFunc);

        public static Try<S, R, Nothing> Try<S, R>(this S subject, Func<S, R> funcToTry, Action<S, Exception> onCatchAction)
            => Prelude.Try(subject, funcToTry, onCatchAction);

        public static Try<S, Nothing, Nothing> Try<S>(this S subject, Action<S> actionToTry, Action<S, Exception> onCatchAction)
          => Prelude.Try(subject, actionToTry, onCatchAction);



        //TRY with CATCH EX 
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry)
            => Prelude.Try(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry)
            => Prelude.Try(subject, actionToTry);

    }


}
