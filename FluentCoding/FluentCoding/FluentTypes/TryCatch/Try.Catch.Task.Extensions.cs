using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class TryExtension
    {
        public static async Task<Try<S, R, E2>> Catch<S, R, E2>(this Task<Try<S, R, Exception>> tried, Func<S, Exception, E2> functOnCatch)
            => await tried switch
            {
                TrySuccess<S, R, Exception>(var s, var r) => new TrySuccess<S, R, E2>(s, r),
                TryFailure<S, R, Exception>(var s, var r, var ex) => new TryFailure<S, R, E2>(s, functOnCatch(s, ex), ex),
                _ => throw Try<S, R, E2>.UnknowImplementation()
            };
    }
}
