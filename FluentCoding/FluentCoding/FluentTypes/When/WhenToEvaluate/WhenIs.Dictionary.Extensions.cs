using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {

        public static IWhen<IDictionary<TK, TV>> ContainsKey<TK, TV>(this IWhenIs<IDictionary<TK, TV>> whenIs, TK key)
            => whenIs.ToWhen(sbj => sbj.ContainsKey(key));

        public static IWhen<IDictionary<TK, TV>> ContainsValue<TK, TV>(this IWhenIs<IDictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item)
            => whenIs.ToWhen(sbj => sbj.Contains(item));

        public static IWhen<Dictionary<TK, TV>> ContainsKey<TK, TV>(this IWhenIs<Dictionary<TK, TV>> whenIs, TK key)
               => whenIs.ToWhen(sbj => sbj.ContainsKey(key));

        public static IWhen<Dictionary<TK, TV>> ContainsValue<TK, TV>(this IWhenIs<Dictionary<TK, TV>> whenIs, KeyValuePair<TK, TV> item)
            => whenIs.ToWhen(sbj => sbj.Contains(item));
    }

}
