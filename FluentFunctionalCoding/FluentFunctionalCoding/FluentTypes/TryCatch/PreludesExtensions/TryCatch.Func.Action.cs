
namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {

        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this Func<S, R> funcToTry, S subject, Func<S, Exception, E> onCatchFunc)
            => FluentFunctionalCoding.Try<S, R, E>.Wrap(subject, funcToTry, onCatchFunc);

        public static Try<S, R, Nothing> Try<S, R>(this Func<S, R> funcToTry, S subject, Action<S, Exception> onCatchAction)
            => FluentFunctionalCoding.Try<S, R, Nothing>.Wrap(subject, funcToTry, onCatchAction);

        public static Try<S, Nothing, E> Try<S, E>(this Action<S> actionToTry, S subject, Func<S, Exception, E> onCatchFunc)
          => FluentFunctionalCoding.Try<S, Nothing, E>.Wrap(subject, actionToTry, onCatchFunc);

        public static Try<S, Nothing, Nothing> Try<S>(this Action<S> actionToTry, S subject, Action<S, Exception> onCatchAction)
          => FluentFunctionalCoding.Try<S, Nothing, Nothing>.Wrap(subject, actionToTry, onCatchAction);



        //TRY with CATCH EX
        public static Try<S, R, Exception> Try<S, R>(this Func<S, R> funcToTry, S subject)
            => FluentFunctionalCoding.Try<S, R, Exception>.Wrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this Action<S> actionToTry, S subject)
            => FluentFunctionalCoding.Try<S, Nothing, Exception>.Wrap(subject, actionToTry);

        public static Try<Nothing, Nothing, Exception> Try(this Action subjectAction)
            => FluentFunctionalCoding.Try<Nothing, Nothing, Exception>.Wrap(Nothing.SoftNull, s => subjectAction());

    }


}
