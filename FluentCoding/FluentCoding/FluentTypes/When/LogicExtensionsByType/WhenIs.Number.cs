using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<decimal> IsGreaterThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false) 
            => new When<decimal>(whenIs._subject, whenIs._subject > value || (allowEquals && whenIs._subject == value));

        public static When<decimal> IsLessThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => new When<decimal>(whenIs._subject, whenIs._subject < value || (allowEquals && whenIs._subject == value));

        public static When<decimal> IsEqualsTo(this WhenIs<decimal> whenIs, decimal value)
            => new When<decimal>(whenIs._subject, whenIs._subject == value);



        public static When<int> IsGreaterThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
          => new When<int>(whenIs._subject, whenIs._subject > value || (allowEquals && whenIs._subject == value));

        public static When<int> IsLessThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
            => new When<int>(whenIs._subject, whenIs._subject < value || (allowEquals && whenIs._subject == value));

        public static When<int> IsEqualsTo(this WhenIs<int> whenIs, int value)
            => new When<int>(whenIs._subject, whenIs._subject == value);


        public static When<long> IsGreaterThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
          => new When<long>(whenIs._subject, whenIs._subject > value || (allowEquals && whenIs._subject == value));

        public static When<long> IsLessThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
            => new When<long>(whenIs._subject, whenIs._subject < value || (allowEquals && whenIs._subject == value));

        public static When<long> IsEqualsTo(this WhenIs<long> whenIs, long value)
            => new When<long>(whenIs._subject, whenIs._subject == value);


        //public static When<IEnumerable<T>> WhenAll<T>(this IEnumerable<T> whenIs.Subject, Func<T, bool> andPredicateOnItems)
        //    => new When<IEnumerable<T>>(whenIs.Subject, whenIs.Subject.All(andPredicateOnItems));
    }
}
