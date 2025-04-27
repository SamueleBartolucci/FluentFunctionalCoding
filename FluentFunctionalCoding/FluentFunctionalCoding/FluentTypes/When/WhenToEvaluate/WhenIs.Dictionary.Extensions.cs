using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {

        // IDictionary
        public static When<IDictionary<TK, TV>> ContainsKey<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, TK key)
            => whenIs._ToWhen(sbj => sbj.ContainsKey(key));

        public static When<IDictionary<TK, TV>> ContainsValue<TK, TV>(this WhenIs<IDictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item)
            => whenIs._ToWhen(sbj => sbj.Contains(item));

        // Dictionary
        public static When<Dictionary<TK, TV>> ContainsKey<TK, TV>(this WhenIs<Dictionary<TK, TV>> whenIs, TK key)
               => whenIs._ToWhen(sbj => sbj.ContainsKey(key));

        public static When<Dictionary<TK, TV>> ContainsValue<TK, TV>(this WhenIs<Dictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item)
            => whenIs._ToWhen(sbj => sbj.Contains(item));
    }

}
