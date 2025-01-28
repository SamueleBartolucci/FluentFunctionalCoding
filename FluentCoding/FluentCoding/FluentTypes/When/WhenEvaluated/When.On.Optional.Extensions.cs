namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static When<Optional<T>> OnTrue<T>(this When<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {
            if (when)
                when._subject.OnSome(actionToCallOnSomeSubject);

            return when;
        }

        public static When<Optional<T>> OnFalse<T>(this When<Optional<T>> when, Action<T> actionToCallOnSomeSubject)
        {
            if (!when)
                when._subject.OnSome(actionToCallOnSomeSubject);

            return when;
        }

        public static When<Optional<T>> OnTrue<T, X>(this When<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (when)
                when._subject.OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }

        public static When<Optional<T>> OnFalse<T, X>(this When<Optional<T>> when, Func<T, X> funcAsActionToCallOnSomeSubject)
        {
            if (!when)
                when._subject.OnSome(funcAsActionToCallOnSomeSubject);

            return when;
        }
    }
}
