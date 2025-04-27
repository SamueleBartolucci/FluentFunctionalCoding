
namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this Func<S, R> funcToTry, S subject, Func<S, Exception, E> onCatchFunc)
            => Prelude.Try(subject, funcToTry, onCatchFunc);

        public static Try<S, R, Nothing> Try<S, R>(this Func<S, R> funcToTry, S subject, Action<S, Exception> onCatchAction)
            => Prelude.Try(subject, funcToTry, onCatchAction);

        public static Try<S, Nothing, E> Try<S, E>(this Action<S> actionToTry, S subject, Func<S, Exception, E> onCatchFunc)
          => Prelude.Try(subject, actionToTry, onCatchFunc);

        public static Try<S, Nothing, Nothing> Try<S>(this Action<S> actionToTry, S subject, Action<S, Exception> onCatchAction)
          => Prelude.Try(subject, actionToTry, onCatchAction);



        //TRY with CATCH EX
        public static Try<S, R, Exception> Try<S, R>(this Func<S, R> funcToTry, S subject)
            => Prelude.Try(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this Action<S> actionToTry, S subject)
            => Prelude.Try(subject, actionToTry);

        public static Try<Nothing, Nothing, Exception> Try(this Action subjectAction)
            => Prelude.Try(Nothing.SoftNull, s => subjectAction());

    }


}
