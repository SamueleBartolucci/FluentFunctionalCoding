using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<string> WhenNullOrEmpty<T>(this WhenIs<string> whenIs) 
            => new When<string>(whenIs._subject, string.IsNullOrEmpty(whenIs._subject));

        public static When<string> WhenNotNullOrEmpty<T>(this WhenIs<string> whenIs)
            => new When<string>(whenIs._subject, !string.IsNullOrEmpty(whenIs._subject));

        public static When<string> WhenEqualsTo<T>(this WhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => new When<string>(whenIs._subject, whenIs._subject?.Equals(compare, options) ?? false);

    }
}
