namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Applies the specified mapping function to each item in the source sequence and returns a projected IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="K">The type of the elements in the resulting sequence.</typeparam>
        /// <param name="subjectsToMap">The source sequence to map from.</param>
        /// <param name="mapFunc">The mapping function to apply to each element.</param>
        /// <returns>An IEnumerable containing the results of applying <paramref name="mapFunc"/> to each element of <paramref name="subjectsToMap"/>, or default if <paramref name="subjectsToMap"/> is null.</returns>
        public static IEnumerable<K> MapAll<T, K>(this IEnumerable<T> subjectsToMap, Func<T, K> mapFunc)
            => subjectsToMap == null ? default : subjectsToMap.Select(mapFunc);
    }
}
