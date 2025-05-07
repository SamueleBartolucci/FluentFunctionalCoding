namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Asynchronously applies the specified mapping function to each item in the awaited source sequence and returns a projected IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="K">The type of the elements in the resulting sequence.</typeparam>
        /// <param name="subjectToMap">A Task that produces the source sequence to map from.</param>
        /// <param name="mapFunc">The mapping function to apply to each element.</param>
        /// <returns>A Task containing an IEnumerable with the results of applying <paramref name="mapFunc"/> to each element of the awaited source sequence.</returns>
        public static async Task<IEnumerable<K>> MapAllAsync<T, K>(this Task<IEnumerable<T>> subjectToMap, Func<T, K> mapFunc)
            => (await subjectToMap).MapAll(mapFunc);

        /// <summary>
        /// Asynchronously applies the specified mapping function to each item in the awaited List and returns a projected IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source list.</typeparam>
        /// <typeparam name="K">The type of the elements in the resulting sequence.</typeparam>
        /// <param name="subjectToMap">A Task that produces the source list to map from.</param>
        /// <param name="mapFunc">The mapping function to apply to each element.</param>
        /// <returns>A Task containing an IEnumerable with the results of applying <paramref name="mapFunc"/> to each element of the awaited list.</returns>
        public static async Task<IEnumerable<K>> MapAllAsync<T, K>(this Task<List<T>> subjectToMap, Func<T, K> mapFunc)
            => (await subjectToMap).MapAll(mapFunc);

        /// <summary>
        /// Asynchronously applies the specified mapping function to each item in the awaited array and returns a projected IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source array.</typeparam>
        /// <typeparam name="K">The type of the elements in the resulting sequence.</typeparam>
        /// <param name="subjectToMap">A Task that produces the source array to map from.</param>
        /// <param name="mapFunc">The mapping function to apply to each element.</param>
        /// <returns>A Task containing an IEnumerable with the results of applying <paramref name="mapFunc"/> to each element of the awaited array.</returns>
        public static async Task<IEnumerable<K>> MapAllAsync<T, K>(this Task<T[]> subjectToMap, Func<T, K> mapFunc)
            => (await subjectToMap).MapAll(mapFunc);
    }
}
