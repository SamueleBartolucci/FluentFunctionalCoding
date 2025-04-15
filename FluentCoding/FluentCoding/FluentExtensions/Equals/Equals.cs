using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Search if at least one item from the domains match the input value
        /// Basic Equals used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="valuesDomainToCompareWith"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsToAny<T>(this T subject, params T[] valuesDomainToCompareWith)
            => subject != null && valuesDomainToCompareWith.Any(domainValue => subject.Equals(domainValue));


        /// <summary>
        /// Search if at least one item from a domains match the input value
        /// The provided equalityComparison function is used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="comparerFunc"></param>
        /// <param name="valuesDomainToCompareWith"></param>
        /// <returns></returns>
        public static bool EqualsToAny<T, K>(this T subject, Func<T, K, bool> comparerFunc, params K[] valuesDomainToCompareWith)
            => subject != null && valuesDomainToCompareWith.Any(valueToCompare => comparerFunc(subject, valueToCompare));
    }
}
