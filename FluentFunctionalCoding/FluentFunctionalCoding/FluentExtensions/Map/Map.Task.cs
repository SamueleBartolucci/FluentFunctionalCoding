namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Asynchronously applies the specified mapping function to the awaited subject and returns the result.
        /// </summary>
        /// <typeparam name="T">The type of the input subject.</typeparam>
        /// <typeparam name="K">The type of the result after mapping.</typeparam>
        /// <param name="subjectToMap">A Task that produces the subject to map from.</param>
        /// <param name="mapFunc">The mapping function to apply.</param>
        /// <returns>A Task containing the result of applying <paramref name="mapFunc"/> to the awaited subject.</returns>
        public static async Task<K> MapAsync<T, K>(this Task<T> subjectToMap, Func<T, K> mapFunc)
            => (await subjectToMap).Map(mapFunc);
    }
}
