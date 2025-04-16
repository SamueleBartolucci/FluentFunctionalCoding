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
        /// Apply a set of functions on each item from the subject (when this is not null) then return the subject
        /// The funct result is discarded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="enumerableSubject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
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
