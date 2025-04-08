namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Optional<T>> Is<T>(this WhenIs<Optional<T>> whenIs, params Func<T, bool>[] predicates)
            => whenIs._whenSubject switch
            {
                Some<T>(var o) => When<Optional<T>>.WhenMatch(o.ToOptional(), predicates.All(p => p(o))),
                None<T> n => When<Optional<T>>.WhenMatch(n, false)
            };

    }
}
