namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static IOutcome<F, T1> Match<F, T, T1>(this IWhen<IOutcome<F, T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when.Subject().MapSuccess(when.IsTrue ? mapOnTrue : mapOnFalse);


        public static IOutcome<F, T> MatchTrue<F, T>(this IWhen<IOutcome<F, T>> when, Func<T, T> mapOnTrue)
            => when.IsTrue ? when.Subject().MapSuccess(mapOnTrue) : when.Subject();

        public static IOutcome<F, T> MatchFalse<F, T>(this IWhen<IOutcome<F, T>> when, Func<T, T> mapOnFalse)
            => !when.IsTrue ? when.Subject().MapSuccess(mapOnFalse) : when.Subject();

    }
}
