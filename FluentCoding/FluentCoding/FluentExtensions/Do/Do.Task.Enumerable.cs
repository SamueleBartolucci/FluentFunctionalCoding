using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Apply a set of actions on each item from the subject (when this is not null) then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerableSubject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<IEnumerable<T>> enumerableSubject, params Action<T>[] actionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(actionsToApplyOnSubject);


        /// <summary>
        /// Apply a set of functions on each item from the subject (when this is not null) then return the subject
        /// The funct result is discarded
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="enumerableSubject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IEnumerable<T>> DoForEachAsync<T, K>(this Task<IEnumerable<T>> enumerableSubject, params Func<T, K>[] functionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(functionsToApplyOnSubject);
    }
}
