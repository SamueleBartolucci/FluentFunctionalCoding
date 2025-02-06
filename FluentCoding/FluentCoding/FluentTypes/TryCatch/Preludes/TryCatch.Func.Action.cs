
namespace FluentCoding
{
    public static partial class Prelude
    {
        
        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this Func<S, R> funcToTry, S subject, Func<S, Exception, E> onCatchFunc)
            => FluentCoding.Try<S, R, E>.ToTryWrap(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this Action<S> actionToTry, S subject, Func<S, Exception, E> onCatchFunc)
          => FluentCoding.Try<S, Nothing, E>.ToTryWrap(subject, s => { actionToTry(s); return Nothing.Null; }, onCatchFunc);


        //TRY with CATCH EX
        public static Try<S, R, Exception> Try<S, R>(this Func<S, R> funcToTry, S subject)
            => FluentCoding.Try<S, R, Exception>.ToTryWrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this Action<S> actionToTry, S subject)
            => FluentCoding.Try<S, Nothing, Exception>.ToTryWrap(subject, s => { actionToTry(s); return Nothing.Null; });

        public static Try<Nothing, Nothing, Exception> Try(this Action subjectAction)
            => FluentCoding.Try<Nothing, Nothing, Exception>.ToTryWrap(Nothing.Null, s => { subjectAction(); return Nothing.Null; });

    }


}
