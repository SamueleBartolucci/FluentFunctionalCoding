namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static IWhen<Optional<T>> OnTrue<T>(this IWhen<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {  
            if (when.IsTrue)
                when.Subject().OnSome(actionToCallOnSomeSubject);

            return when;
        }

        public static IWhen<Optional<T>> OnFalse<T>(this IWhen<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {
            if (!when.IsTrue)
                when.Subject().OnSome(actionToCallOnSomeSubject);

            return when;
        }

        public static IWhen<Optional<T>> OnTrue<T, X>(this IWhen<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (when.IsTrue)
                when.Subject().OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }

        public static IWhen<Optional<T>> OnFalse<T, X>(this IWhen<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (!when.IsTrue)
                when.Subject().OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }
    }
}
