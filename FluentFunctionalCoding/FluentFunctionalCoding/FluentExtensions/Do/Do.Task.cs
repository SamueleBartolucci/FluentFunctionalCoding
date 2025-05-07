using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Asynchronously applies one or more actions to the awaited subject (if not null) and then returns the subject.
        /// Useful for performing side effects such as logging or debugging in asynchronous fluent chains.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <param name="subject">The Task returning the object to apply actions to.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to the subject.</param>
        /// <returns>A Task containing the original subject after actions are applied, or default if subject is null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T>(this Task<T> subject, params Action<T>[] actionsToApplyOnSubject)
            => (await subject).Do(actionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies one or more functions to the awaited subject (if not null) and then returns the subject.
        /// The function results are discarded. Useful for side effects in asynchronous fluent chains.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="subject">The Task returning the object to apply functions to.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to the subject.</param>
        /// <returns>A Task containing the original subject after functions are applied, or default if subject is null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> DoAsync<T, K>(this Task<T> subject, params Func<T, K>[] functionsToApplyOnSubject)
            => (await subject).Do(functionsToApplyOnSubject);
    }
}
