
namespace FluentCoding
{
    public static partial class Prelude
    {
        
        //TRY with custom CATCH
        public static Try<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => FluentCoding.Try<S, R, E>.Wrap(subject, funcToTry, onCatchFunc);

        public static Try<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
          => FluentCoding.Try<S, Nothing, E>.Wrap(subject, s => { actionToTry(s); return Nothing.SoftNull; }, onCatchFunc);


        //TRY with CATCH EX 
        public static Try<S, R, Exception> Try<S, R>(this S subject, Func<S, R> funcToTry)
            => FluentCoding.Try<S, R, Exception>.Wrap(subject, funcToTry);

        public static Try<S, Nothing, Exception> Try<S>(this S subject, Action<S> actionToTry)
            => FluentCoding.Try<S, Nothing, Exception>.Wrap(subject, s => { actionToTry(s); return Nothing.SoftNull; });

    }


}
