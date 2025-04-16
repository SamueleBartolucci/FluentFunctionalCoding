
namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {

        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this Func<S, R> funcToTry, S subject, Func<S, Exception, E> onCatchFunc)
            => FluentFunctionalCoding.Try<S, R, E>.Wrap(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this Action<S> actionToTry, S subject, Func<S, Exception, E> onCatchFunc)
          => FluentFunctionalCoding.Try<S, Nothing, E>.Wrap(subject, s => { actionToTry(s); return Nothing.SoftNull; }, onCatchFunc);


        //TRY with CATCH EX
        public static Try<S, R, Exception> Try<S, R>(this Func<S, R> funcToTry, S subject)
            => FluentFunctionalCoding.Try<S, R, Exception>.Wrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this Action<S> actionToTry, S subject)
            => FluentFunctionalCoding.Try<S, Nothing, Exception>.Wrap(subject, s => { actionToTry(s); return Nothing.SoftNull; });

        public static Try<Nothing, Nothing, Exception> Try(this Action subjectAction)
            => FluentFunctionalCoding.Try<Nothing, Nothing, Exception>.Wrap(Nothing.SoftNull, s => { subjectAction(); return Nothing.SoftNull; });

    }


}
