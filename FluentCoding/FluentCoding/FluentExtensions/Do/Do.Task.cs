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
        /// <param name="subject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T>(this Task<T> subject, params Action<T>[] actionsToApplyOnSubject)
            => (await subject).Do(actionsToApplyOnSubject);

        /// <summary>
        /// Apply a set of functions to the subject (when this is not null) and then return the subject
        /// /// The funct result is discarded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T>(this Task<T> subject, params Func<T, T>[] functionsToApplyOnSubject)
            => (await subject).Do(functionsToApplyOnSubject);
    }
}
