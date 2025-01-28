namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<IEnumerable<T>> Any<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => When<IEnumerable<T>>.WhenMatch(whenIs._subject, whenIs._subject.Any(orPredicatesOnItems));

        public static When<IEnumerable<T>> All<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => When<IEnumerable<T>>.WhenMatch(whenIs._subject, whenIs._subject.All(andPredicatesOnItems));
    }
}
