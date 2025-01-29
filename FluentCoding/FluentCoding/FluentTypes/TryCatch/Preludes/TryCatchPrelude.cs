
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static TryCatch<S, R> Try<S,R>(this S subject, Func<S, R> funcToTry) 
            => TryCatch<S, R>.ToTry(subject, funcToTry);

        public static TryCatch<S, Nothing> Try<S>(this S subject, Action<S> actionToTry) 
            => TryCatch<S, Nothing>.ToTry(subject, actionToTry);
        
        public static TryCatch<Nothing, Nothing> Try(this Action subjectAction) 
            => TryCatch<Nothing, Nothing>.ToTry(Nothing.Null, sbj => subjectAction());


        public static TryCatch<S, R, E> Try<S, R, E>(this S subject, Func<S, R> funcToTry, Func<S, Exception, E> onCatchFunc)
            => TryCatch<S, R, E>.ToTry(subject, funcToTry, onCatchFunc);

        public static TryCatch<S, Nothing, E> Try<S, E>(this S subject, Action<S> actionToTry, Func<S, Exception, E> onCatchFunc)
            => TryCatch<S, Nothing, E>.ToTry(subject, actionToTry, onCatchFunc);

    }

}
