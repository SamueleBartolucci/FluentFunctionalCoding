namespace FluentFunctionalCoding
{
    public static partial class WhenExtension
    {
        /// <summary>
        /// Applies the specified mapping functions to the subject depending on whether the condition is true or false.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="T1">The return type of the mapping functions.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>An <see cref="Optional{T1}"/> with the mapped value.</returns>
        public static Optional<T1> Match<T, T1>(this When<Optional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.Map(when.IsTrue ? mapOnTrue : mapOnFalse);

        /// <summary>
        /// Applies the specified mapping function if the condition is true; otherwise returns the subject unchanged.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <returns>An <see cref="Optional{T}"/> with the mapped or original value.</returns>
        public static Optional<T> MatchTrue<T>(this When<Optional<T>> when, Func<T, T> mapOnTrue)
        => when.IsTrue ? when._subject.Map(mapOnTrue) : when._subject;

        /// <summary>
        /// Applies the specified mapping function if the condition is false; otherwise returns the subject unchanged.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">The <see cref="When{Optional{T}}"/> instance.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>An <see cref="Optional{T}"/> with the mapped or original value.</returns>
        public static Optional<T> MatchFalse<T>(this When<Optional<T>> when, Func<T, T> mapOnFalse)
             => !when.IsTrue ? when._subject.Map(mapOnFalse) : when._subject;
    }
}
