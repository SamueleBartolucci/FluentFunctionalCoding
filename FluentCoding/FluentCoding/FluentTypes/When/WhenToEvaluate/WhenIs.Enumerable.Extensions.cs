using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<IEnumerable<T>> Any<T>(this IWhenIs<IEnumerable<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static IWhen<IEnumerable<T>> All<T>(this IWhenIs<IEnumerable<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.All(andPredicatesOnItems));


        public static IWhen<List<T>> Any<T>(this IWhenIs<List<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static IWhen<List<T>> All<T>(this IWhenIs<List<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.All(andPredicatesOnItems));
    

        public static IWhen<IList<T>> Any<T>(this IWhenIs<IList<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static IWhen<IList<T>> All<T>(this IWhenIs<IList<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs.ToWhen(sbj => sbj.All(andPredicatesOnItems));
    }
}


