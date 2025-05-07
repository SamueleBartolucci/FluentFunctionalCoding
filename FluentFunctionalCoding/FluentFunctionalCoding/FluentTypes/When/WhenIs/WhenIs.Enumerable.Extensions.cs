using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{T}"/> to perform conditional checks on <see cref="IEnumerable{T}"/>, <see cref="List{T}"/>, and <see cref="IList{T}"/> collections.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether any element of the sequence satisfies a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IEnumerable{T}}"/> instance to extend.</param>
        /// <param name="orPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{IEnumerable{T}}"/> indicating if any element matches the predicate.</returns>
        public static When<IEnumerable<T>> Any<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        /// <summary>
        /// Determines whether all elements of the sequence satisfy a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IEnumerable{T}}"/> instance to extend.</param>
        /// <param name="andPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{IEnumerable{T}}"/> indicating if all elements match the predicate.</returns>
        public static When<IEnumerable<T>> All<T>(this WhenIs<IEnumerable<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));

        /// <summary>
        /// Determines whether any element of the list satisfies a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{List{T}}"/> instance to extend.</param>
        /// <param name="orPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{List{T}}"/> indicating if any element matches the predicate.</returns>
        public static When<List<T>> Any<T>(this WhenIs<List<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        /// <summary>
        /// Determines whether all elements of the list satisfy a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{List{T}}"/> instance to extend.</param>
        /// <param name="andPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{List{T}}"/> indicating if all elements match the predicate.</returns>
        public static When<List<T>> All<T>(this WhenIs<List<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));

        /// <summary>
        /// Determines whether any element of the <see cref="IList{T}"/> satisfies a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IList{T}}"/> instance to extend.</param>
        /// <param name="orPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{IList{T}}"/> indicating if any element matches the predicate.</returns>
        public static When<IList<T>> Any<T>(this WhenIs<IList<T>> whenIs, Func<T, bool> orPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.Any(orPredicatesOnItems));

        /// <summary>
        /// Determines whether all elements of the <see cref="IList{T}"/> satisfy a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list.</typeparam>
        /// <param name="whenIs">The <see cref="WhenIs{IList{T}}"/> instance to extend.</param>
        /// <param name="andPredicatesOnItems">A function to test each element for a condition. Returns true if the element matches the condition.</param>
        /// <returns>A <see cref="When{IList{T}}"/> indicating if all elements match the predicate.</returns>
        public static When<IList<T>> All<T>(this WhenIs<IList<T>> whenIs, Func<T, bool> andPredicatesOnItems)
            => whenIs._ToWhen(sbj => sbj.All(andPredicatesOnItems));
    }
}


