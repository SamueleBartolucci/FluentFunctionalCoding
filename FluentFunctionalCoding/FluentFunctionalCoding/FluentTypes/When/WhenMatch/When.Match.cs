namespace FluentFunctionalCoding
{
    public partial record When<T>
    {
        /// <summary>
        /// Applies the specified mapping functions depending on whether the condition is true or false.
        /// </summary>
        /// <typeparam name="T1">The return type of the mapping functions.</typeparam>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>The result of the selected mapping function.</returns>
        public T1 Match<T1>(Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => (IsTrue ? mapOnTrue : mapOnFalse)(_subject);

        /// <summary>
        /// Applies the specified mapping function if the condition is true; otherwise returns the subject unchanged.
        /// </summary>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <returns>The mapped or original subject.</returns>
        public T MatchTrue(Func<T, T> mapOnTrue)
            => IsTrue ? mapOnTrue(_subject) : _subject;

        /// <summary>
        /// Applies the specified mapping function if the condition is false; otherwise returns the subject unchanged.
        /// </summary>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>The mapped or original subject.</returns>
        public T MatchFalse(Func<T, T> mapOnFalse)
            => IsTrue ? _subject : mapOnFalse(_subject);
    }
}
