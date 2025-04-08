namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<decimal> IsGreaterThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => When<decimal>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject > value || (allowEquals && whenIs._whenSubject == value));

        public static When<decimal> IsLessThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => When<decimal>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject < value || (allowEquals && whenIs._whenSubject == value));

        public static When<decimal> IsEqualsTo(this WhenIs<decimal> whenIs, decimal value)
            => When<decimal>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject == value);



        public static When<int> IsGreaterThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
          => When<int>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject > value || (allowEquals && whenIs._whenSubject == value));

        public static When<int> IsLessThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
            => When<int>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject < value || (allowEquals && whenIs._whenSubject == value));

        public static When<int> IsEqualsTo(this WhenIs<int> whenIs, int value)
            => When<int>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject == value);


        public static When<long> IsGreaterThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
          => When<long>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject > value || (allowEquals && whenIs._whenSubject == value));

        public static When<long> IsLessThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
            => When<long>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject < value || (allowEquals && whenIs._whenSubject == value));

        public static When<long> IsEqualsTo(this WhenIs<long> whenIs, long value)
            => When<long>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject == value);


        //public static When<IEnumerable<T>> WhenAll<T>(this IEnumerable<T> whenIs.Subject, Func<T, bool> andPredicateOnItems)
        //    => new When<IEnumerable<T>>(whenIs.Subject, whenIs.Subject.All(andPredicateOnItems));
    }
}
