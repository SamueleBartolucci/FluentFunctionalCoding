namespace FluentFunctionalCoding
{
    public static partial class WhenForTasks
    {
        /// <summary>
        /// Asynchronously applies the specified mapping function if the condition is true; otherwise returns the subject unchanged.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <returns>A task that produces the mapped or original subject.</returns>
        public static async Task<T> MatchTrueAsynch<T>(this Task<When<T>> when, Func<T, T> mapOnTrue)
         => (await when).MatchTrue(mapOnTrue);
        
        /// <summary>
        /// Asynchronously applies the specified mapping function if the condition is false; otherwise returns the subject unchanged.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>A task that produces the mapped or original subject.</returns>
        public static async Task<T> MatchFalseAsynch<T>(this Task<When<T>> when, Func<T, T> mapOnFalse)
         => (await when).MatchFalse(mapOnFalse);

        /// <summary>
        /// Asynchronously applies the specified mapping functions depending on whether the condition is true or false.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="T1">The return type of the mapping functions.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="mapOnTrue">The function to apply if the condition is true.</param>
        /// <param name="mapOnFalse">The function to apply if the condition is false.</param>
        /// <returns>A task that produces the result of the selected mapping function.</returns>
        public static async Task<T1> MatchAsynch<T, T1>(this Task<When<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
         => (await when).Match(mapOnTrue, mapOnFalse);

    }
}
