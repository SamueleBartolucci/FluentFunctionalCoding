using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Asynchronously applies a set of actions to each item in the awaited enumerable subject and returns the original enumerable.
        /// Useful for performing side effects on asynchronous collections in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <param name="enumerableSubject">The Task returning an enumerable to iterate over.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after actions are applied.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<IEnumerable<T>> enumerableSubject, params Action<T>[] actionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(actionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies a set of actions to each item in the awaited List subject and returns the original enumerable.
        /// Useful for performing side effects on asynchronous collections in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the list.</typeparam>
        /// <param name="enumerableSubject">The Task returning a List to iterate over.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after actions are applied.</returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<List<T>> enumerableSubject, params Action<T>[] actionsToApplyOnSubject)
           => (await enumerableSubject).DoForEach(actionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies a set of actions to each item in the awaited array subject and returns the original enumerable.
        /// Useful for performing side effects on asynchronous collections in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the array.</typeparam>
        /// <param name="enumerableSubject">The Task returning an array to iterate over.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after actions are applied.</returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<T[]> enumerableSubject, params Action<T>[] actionsToApplyOnSubject)
           => (await enumerableSubject).DoForEach(actionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies a set of functions to each item in the awaited enumerable subject and returns the original enumerable.
        /// The function results are discarded. Useful for side effects in asynchronous fluent chains.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="enumerableSubject">The Task returning an enumerable to iterate over.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after functions are applied.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IEnumerable<T>> DoForEachAsync<T, K>(this Task<IEnumerable<T>> enumerableSubject, params Func<T, K>[] functionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(functionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies a set of functions to each item in the awaited List subject and returns the original enumerable.
        /// The function results are discarded. Useful for side effects in asynchronous fluent chains.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the list.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="enumerableSubject">The Task returning a List to iterate over.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after functions are applied.</returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T, K>(this Task<List<T>> enumerableSubject, params Func<T, K>[] functionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(functionsToApplyOnSubject);

        /// <summary>
        /// Asynchronously applies a set of functions to each item in the awaited array subject and returns the original enumerable.
        /// The function results are discarded. Useful for side effects in asynchronous fluent chains.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the array.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="enumerableSubject">The Task returning an array to iterate over.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to each element.</param>
        /// <returns>A Task containing the original enumerable after functions are applied.</returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T, K>(this Task<T[]> enumerableSubject, params Func<T, K>[] functionsToApplyOnSubject)
            => (await enumerableSubject).DoForEach(functionsToApplyOnSubject);
    }
}
