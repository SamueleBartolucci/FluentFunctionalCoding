
namespace FluentCoding
{
    public static partial class Prelude
    {
        
        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => FluentCoding.Try<S, R, E>.ToTryWrap(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
          => FluentCoding.Try<S, Nothing, E>.ToTryWrap(subject, s => { actionToTry(s); return Nothing.Null; }, onCatchFunc);


        //TRY with CATCH EX 
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry)
            => FluentCoding.Try<S, R, Exception>.ToTryWrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry)
            => FluentCoding.Try<S, Nothing, Exception>.ToTryWrap(subject, s => { actionToTry(s); return Nothing.Null; });

    }


}
