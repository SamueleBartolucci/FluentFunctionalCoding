using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Determines whether the subject is equal to any of the provided values using the default equality comparison.
        /// </summary>
        /// <typeparam name="T">The type of the subject and values to compare.</typeparam>
        /// <param name="subject">The value to compare.</param>
        /// <param name="valuesDomainToCompareWith">A set of values to compare against the subject.</param>
        /// <returns>True if the subject equals at least one value in the set; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsToAny<T>(this T subject, params T[] valuesDomainToCompareWith)
            => subject != null && valuesDomainToCompareWith.Any(domainValue => subject.Equals(domainValue));

        /// <summary>
        /// Determines whether the subject is equal to any of the provided values using a custom comparison function.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="K">The type of the values to compare against.</typeparam>
        /// <param name="subject">The value to compare.</param>
        /// <param name="comparerFunc">A function that defines how to compare the subject and each value.</param>
        /// <param name="valuesDomainToCompareWith">A set of values to compare against the subject.</param>
        /// <returns>True if the comparison function returns true for at least one value in the set; otherwise, false.</returns>
        public static bool EqualsToAny<T, K>(this T subject, Func<T, K, bool> comparerFunc, params K[] valuesDomainToCompareWith)
            => subject != null && valuesDomainToCompareWith.Any(valueToCompare => comparerFunc(subject, valueToCompare));
    }
}
