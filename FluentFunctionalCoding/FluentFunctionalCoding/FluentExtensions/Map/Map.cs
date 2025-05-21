namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Applies the specified mapping function to the subject and returns the result.
        /// </summary>
        /// <typeparam name="T">The type of the input subject.</typeparam>
        /// <typeparam name="K">The type of the result after mapping.</typeparam>
        /// <param name="subjectToMap">The object to map from.</param>
        /// <param name="mapFunc">The mapping function to apply.</param>
        /// <returns>The result of applying <paramref name="mapFunc"/> to <paramref name="subjectToMap"/>, or default if <paramref name="subjectToMap"/> is null.</returns>
        public static K Map<T, K>(this T subjectToMap, Func<T, K> mapFunc) => subjectToMap == null ? default : mapFunc(subjectToMap);

        /// <summary>
        /// Applies the specified mapping function to the subject inside a using statement and returns the result.
        /// </summary>
        /// <typeparam name="T">The type of the input subject, must implement IDisposable.</typeparam>
        /// <typeparam name="K">The type of the result after mapping.</typeparam>
        /// <param name="subjectToMap">The object to map from.</param>
        /// <param name="mapFunc">The mapping function to apply.</param>
        /// <returns>The result of applying <paramref name="mapFunc"/> to <paramref name="subjectToMap"/>, or default if <paramref name="subjectToMap"/> is null.</returns>
        public static K MapUsing<T, K>(this T subjectToMap, Func<T, K> mapFunc) where T : IDisposable
        {
            if (subjectToMap == null) return default!;
            using (subjectToMap)
                return mapFunc(subjectToMap);
        }
    }
}
