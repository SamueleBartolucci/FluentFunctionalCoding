using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Apply a set of actions to the subject (when this is not null) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actionSubject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T>(this Task<T> actionSubject, params Action<T>[] actionsToApplyOnSubject)
            => (await actionSubject).Do(actionsToApplyOnSubject);

        /// <summary>
        /// Apply a set of functions to the subject (when this is not null) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actionSubject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T>(this Task<T> actionSubject, params Func<T, T>[] functionsToApplyOnSubject)
            => (await actionSubject).Do(functionsToApplyOnSubject);
    }
}
