using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        
        public static When<IEnumerable<T>> Any<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static When<IEnumerable<T>> All<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));




        public static When<List<T>> Any<T>(this WhenIs<List<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static When<List<T>> All<T>(this WhenIs<List<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));
    

        public static When<IList<T>> Any<T>(this WhenIs<IList<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        public static When<IList<T>> All<T>(this WhenIs<IList<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));
    }
}


