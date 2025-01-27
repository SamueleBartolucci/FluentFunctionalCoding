using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class Prelude
    {     
        public static async Task<WhenIs<T>> WhenAsync<T>(this Task<T> whenSubject)
        {
            await whenSubject;
            return new WhenIs<T>(whenSubject.Result);
        }
    }
}
