namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Optional<T>> Is<T>(this WhenIs<Optional<T>> whenIs, params Func<T, bool>[] predicates)
            => When<Optional<T>>.WhenMatch(whenIs._subject, predicates.All(p => whenIs._subject.Match(p, () => false)));

    }
}
