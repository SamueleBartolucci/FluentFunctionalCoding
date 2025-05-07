using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Applies one or more actions to each item in the enumerable subject (if not null), then returns the original enumerable.
        /// Useful for performing side effects such as logging or mutation in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <param name="enumerableSubject">The enumerable to iterate over.</param>
        /// <param name="actionsToApplyOnSubject">Actions to apply to each element.</param>
        /// <returns>The original enumerable after actions are applied, or null if enumerableSubject is null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> enumerableSubject, params Action<T>[] actionsToApplyOnSubject)
        {
            if (enumerableSubject != null)
            {                
                foreach (var itemFromSubject in enumerableSubject)
                    foreach (var actionToApply in actionsToApplyOnSubject)
                        actionToApply(itemFromSubject);
            }

            return enumerableSubject;
        }

        /// <summary>
        /// Applies one or more functions to each item in the enumerable subject (if not null), then returns the original enumerable.
        /// The function results are discarded. Useful for side effects in a fluent chain.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <typeparam name="K">Return type of the functions (ignored).</typeparam>
        /// <param name="enumerableSubject">The enumerable to iterate over.</param>
        /// <param name="functionsToApplyOnSubject">Functions to apply to each element.</param>
        /// <returns>The original enumerable after functions are applied, or null if enumerableSubject is null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> DoForEach<T, K>(this IEnumerable<T> enumerableSubject, params Func<T, K>[] functionsToApplyOnSubject)
        {
            if (enumerableSubject != null)
            {
                foreach (var itemFromSubject in enumerableSubject)
                    foreach (var funcToApplyOnSubject in functionsToApplyOnSubject)
                        funcToApplyOnSubject(itemFromSubject);
            }
            return enumerableSubject;
        }
    }
}
