using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<decimal> IsGreaterThan(this IWhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => whenIs.ToWhen(sbj => sbj > value || (allowEquals && sbj == value));

        public static IWhen<decimal> IsLessThan(this IWhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => whenIs.ToWhen(sbj => sbj < value || (allowEquals && sbj == value));

        public static IWhen<decimal> IsEqualsTo(this IWhenIs<decimal> whenIs, decimal value)
            => whenIs.ToWhen(sbj => sbj == value);



        public static IWhen<int> IsGreaterThan(this IWhenIs<int> whenIs, int value, bool allowEquals = false)
          => whenIs.ToWhen(sbj => sbj  > value || (allowEquals && sbj == value));

        public static IWhen<int> IsLessThan(this IWhenIs<int> whenIs, int value, bool allowEquals = false)
            => whenIs.ToWhen(sbj => sbj  < value || (allowEquals && sbj == value));

        public static IWhen<int> IsEqualsTo(this IWhenIs<int> whenIs, int value)
            => whenIs.ToWhen(sbj => sbj  == value);


        public static IWhen<long> IsGreaterThan(this IWhenIs<long> whenIs, long value, bool allowEquals = false)
          => whenIs.ToWhen(sbj => sbj  > value || (allowEquals && sbj == value));

        public static IWhen<long> IsLessThan(this IWhenIs<long> whenIs, long value, bool allowEquals = false)
            => whenIs.ToWhen(sbj => sbj  < value || (allowEquals && sbj == value));

        public static IWhen<long> IsEqualsTo(this IWhenIs<long> whenIs, long value)
            => whenIs.ToWhen(sbj => sbj  == value);


        //public static IWhen<IEnumerable<T>> WhenAll<T>(this IEnumerable<T> whenIs.Subject, Func<T, bool> andPredicateOnItems)
        //    => new When<IEnumerable<T>>(whenIs.Subject, whenIs.Subject.All(andPredicateOnItems));
    }
}
