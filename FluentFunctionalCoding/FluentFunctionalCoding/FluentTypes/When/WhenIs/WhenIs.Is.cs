// Provides extension methods for conditional matching ("when" logic) on a subject of type T.
// These methods allow for fluent, functional-style conditional checks.
//
// Usage examples:
//   var result = new WhenIs<int>(value).Is(x => x > 0);
//   var result = new WhenIs<string>(str).IsNull();
//
// Methods:
//   - Is(bool isTrue): Matches if the provided boolean is true.
//   - Is(params Func<bool>[] predicates): Matches if all provided predicates return true.
//   - Is(params Func<T, bool>[] predicates): Matches if all provided predicates return true for the subject.
//   - IsNull(): Matches if the subject is null.
//   - IsNotNull(): Matches if the subject is not null.
//   - IsEqualsToAny(params T[] valuesDomainToCompareWith): Matches if the subject equals any of the provided values.
//   - IsEqualsToAny<K>(Func<T, K, bool> comparerFunc, params K[] valuesDomainToCompareWith): Matches if the subject equals any of the provided values using a custom comparer.

namespace FluentFunctionalCoding
{
    public partial record WhenIs<T>
    {       
        /// <summary>
        /// Matches if the provided boolean is true.
        /// </summary>
        /// <param name="isTrue">A boolean value to match against.</param>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> Is(bool isTrue) => Prelude._WhenMatch(_whenSubject, isTrue);

        /// <summary>
        /// Matches if all provided predicates return true.
        /// </summary>
        /// <param name="predicates">An array of predicates to evaluate.</param>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> Is(params Func<bool>[] predicates) => Prelude._WhenMatch(_whenSubject, predicates.All(predicate => predicate()));

        /// <summary>
        /// Matches if all provided predicates return true for the subject.
        /// </summary>
        /// <param name="predicates">An array of predicates that take the subject as input.</param>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> Is(params Func<T, bool>[] predicates) => Prelude._WhenMatch(_whenSubject, predicates.All(predidate => predidate(_whenSubject)));

        /// <summary>
        /// Matches if the subject is null.
        /// </summary>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> IsNull() => Prelude._WhenMatch(_whenSubject, _whenSubject == null);

        /// <summary>
        /// Matches if the subject is not null.
        /// </summary>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> IsNotNull() => Prelude._WhenMatch(_whenSubject, _whenSubject != null);

        /// <summary>
        /// Matches if the subject equals any of the provided values.
        /// </summary>
        /// <param name="valuesDomainToCompareWith">An array of values to compare with the subject.</param>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> IsEqualsToAny(params T[] valuesDomainToCompareWith) => Prelude._WhenMatch(_whenSubject, _whenSubject.EqualsToAny(valuesDomainToCompareWith));

        /// <summary>
        /// Matches if the subject equals any of the provided values using a custom comparer.
        /// </summary>
        /// <param name="comparerFunc">A custom comparer function.</param>
        /// <param name="valuesDomainToCompareWith">An array of values to compare with the subject.</param>
        /// <returns>A <see cref="When{T}"/> representing the match result.</returns>
        public When<T> IsEqualsToAny<K>(Func<T, K, bool> comparerFunc, params K[] valuesDomainToCompareWith) => Prelude._WhenMatch(_whenSubject, _whenSubject.EqualsToAny(comparerFunc, valuesDomainToCompareWith));
    }
}
