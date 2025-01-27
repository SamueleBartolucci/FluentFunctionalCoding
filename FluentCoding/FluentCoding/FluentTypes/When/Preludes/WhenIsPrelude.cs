using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class Prelude
    {
        public static WhenIs<T> When<T>(this T whenSubject) => new WhenIs<T>(whenSubject); 
        //public static WhenIs<T> When<T>(this T whenSubject, params Func<T, bool>[] andPredicatesOnSubject) => new When<T> (whenSubject, andPredicatesOnSubject);

    }
}
