namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Apply the mapping function on the subject and return the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subjectToMap"></param>
        /// <param name="mapFunc"></param>
        /// <returns></returns>
        public static K Map<T, K>(this T subjectToMap, Func<T, K> mapFunc) => subjectToMap == null ? default : mapFunc(subjectToMap);
    }
}
