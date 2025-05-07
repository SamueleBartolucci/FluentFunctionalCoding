namespace FluentFunctionalCoding
{
    public static partial class WhenForTasks
    {
        /// <summary>
        /// Asynchronously executes the specified action if the condition is true.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="actionToCallOnSubject">The action to execute if the condition is true.</param>
        /// <returns>A task that produces the original <see cref="When{T}"/> instance.</returns>
        public static async Task<When<T>> OnTrueAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnTrue(actionToCallOnSubject);

        /// <summary>
        /// Asynchronously executes the specified action if the condition is false.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="actionToCallOnSubject">The action to execute if the condition is false.</param>
        /// <returns>A task that produces the original <see cref="When{T}"/> instance.</returns>
        public static async Task<When<T>> OnFalseAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);

        /// <summary>
        /// Asynchronously executes the specified function if the condition is true.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="actionToCallOnSubject">The function to execute if the condition is true.</param>
        /// <returns>A task that produces the original <see cref="When{T}"/> instance.</returns>
        public static async Task<When<T>> OnTrueAsynch<T, X>(this Task<When<T>> when, Func<T, X> actionToCallOnSubject)
           => (await when).OnTrue(actionToCallOnSubject);

        /// <summary>
        /// Asynchronously executes the specified function if the condition is false.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="X">The return type of the function.</typeparam>
        /// <param name="when">A task that produces a <see cref="When{T}"/>.</param>
        /// <param name="actionToCallOnSubject">The function to execute if the condition is false.</param>
        /// <returns>A task that produces the original <see cref="When{T}"/> instance.</returns>
        public static async Task<When<T>> OnFalseAsynch<T, X>(this Task<When<T>> when, Func<T, X> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);
    }
}
