namespace FluentFunctionalCoding
{
    public static partial class WhenExtension
    {
        /// <summary>
        /// Applies the specified mapping functions to the success value of the outcome depending on whether the condition is true or false.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <typeparam name="T">The success type.</typeparam>
        /// <typeparam name="T1">The return type of the mapping functions.</typeparam>
        /// <param name="when">The <see cref="When{Outcome{F, T}}"/> instance.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>An <see cref="Outcome{F, T1}"/> with the mapped value.</returns>
        public static Outcome<F, T1> Match<F, T, T1>(this When<Outcome<F, T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.MapSuccess(when.IsTrue ? mapOnTrue : mapOnFalse);

        /// <summary>
        /// Applies the specified mapping function to the success value if the condition is true; otherwise returns the original outcome.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <typeparam name="T">The success type.</typeparam>
        /// <param name="when">The <see cref="When{Outcome{F, T}}"/> instance.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <returns>An <see cref="Outcome{F, T}"/> with the mapped or original value.</returns>
        public static Outcome<F, T> MatchTrue<F, T>(this When<Outcome<F, T>> when, Func<T, T> mapOnTrue)
            => when.IsTrue ? when._subject.MapSuccess(mapOnTrue) : when._subject;

        /// <summary>
        /// Applies the specified mapping function to the success value if the condition is false; otherwise returns the original outcome.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <typeparam name="T">The success type.</typeparam>
        /// <param name="when">The <see cref="When{Outcome{F, T}}"/> instance.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>An <see cref="Outcome{F, T}"/> with the mapped or original value.</returns>
        public static Outcome<F, T> MatchFalse<F, T>(this When<Outcome<F, T>> when, Func<T, T> mapOnFalse)
            => !when.IsTrue ? when._subject.MapSuccess(mapOnFalse) : when._subject;
    }
}
