namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<IDictionary<TK, TV>> ContainsKey<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, TK key)
            => When<IDictionary<TK, TV>>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject.ContainsKey(key));

        public static When<IDictionary<TK, TV>> ContainsValue<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item)
            => When<IDictionary<TK, TV>>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject.Contains(item));

    }
}
