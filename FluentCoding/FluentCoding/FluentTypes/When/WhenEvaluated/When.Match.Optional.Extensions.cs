namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static IOptional<T1> Match<T, T1>(this IWhen<IOptional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when.Subject().Map(when.IsTrue ? mapOnTrue : mapOnFalse);

        public static IOptional<T> MatchTrue<T>(this IWhen<IOptional<T>> when, Func<T, T> mapOnTrue)
        => when.IsTrue ? when.Subject().Map(mapOnTrue) : when.Subject();

        public static IOptional<T> MatchFalse<T>(this IWhen<IOptional<T>> when, Func<T, T> mapOnFalse)
             => !when.IsTrue ? when.Subject().Map(mapOnFalse) : when.Subject();
    }
}
