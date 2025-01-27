using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenForTasks
    {

        public static async Task<When<T>> OnTrueAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnTrue(actionToCallOnSubject);

        public static async Task<When<T>> OnFalseAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);

        public static async Task<T> MatchTrueAsynch<T>(this Task<When<T>> when, Func<T, T> mapOnTrue)
         => (await when).MatchTrue(mapOnTrue);

        public static async Task<T> MatchFalseAsynch<T>(this Task<When<T>> when, Func<T, T> mapOnFalse)
         => (await when).MatchFalse(mapOnFalse);

        public static async Task<T1> MatchAsynch<T, T1>(this Task<When<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
         => (await when).Match(mapOnTrue, mapOnFalse);

    }
}
