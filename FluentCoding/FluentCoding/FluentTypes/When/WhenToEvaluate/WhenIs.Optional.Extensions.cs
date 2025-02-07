namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Optional<T>> Is<T>(this WhenIs<Optional<T>> whenIs, params Func<T, bool>[] predicates)
            => whenIs._subject switch 
            {
                OptionalJust<T>(var o) => When<Optional<T>>.WhenMatch(o.Some(), predicates.All(p => p(o))),
                OptionalNone<T> n => When<Optional<T>>.WhenMatch(n, false)
            };

    }
}
