namespace FluentFunctionalCoding
{
    public static partial class WhenExtension
    {
        public static Optional<T1> Match<T, T1>(this IWhen<Optional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when.Subject().Map(when.IsTrue ? mapOnTrue : mapOnFalse);

        public static Optional<T> MatchTrue<T>(this IWhen<Optional<T>> when, Func<T, T> mapOnTrue)
        => when.IsTrue ? when.Subject().Map(mapOnTrue) : when.Subject();

        public static Optional<T> MatchFalse<T>(this IWhen<Optional<T>> when, Func<T, T> mapOnFalse)
             => !when.IsTrue ? when.Subject().Map(mapOnFalse) : when.Subject();
    }
}
