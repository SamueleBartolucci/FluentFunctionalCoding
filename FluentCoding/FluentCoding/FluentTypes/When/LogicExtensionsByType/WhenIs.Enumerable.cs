using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<IEnumerable<T>> Any<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> orPredicateOnItems) 
            => new When<IEnumerable<T>>(whenIs._subject, whenIs._subject.Any(orPredicateOnItems));

        public static When<IEnumerable<T>> All<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> andPredicateOnItems)
            => new When<IEnumerable<T>>(whenIs._subject, whenIs._subject.All(andPredicateOnItems));
    }
}
