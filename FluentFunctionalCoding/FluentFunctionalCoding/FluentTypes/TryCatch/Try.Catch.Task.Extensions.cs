namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {
        /// <summary>
        /// Asynchronously adds a custom catch handler to a Task of Try, mapping the exception to a new error type.
        /// </summary>
        /// <typeparam name="S">The input type.</typeparam>
        /// <typeparam name="R">The output type.</typeparam>
        /// <typeparam name="E2">The new error type.</typeparam>
        /// <param name="tried">The Task of Try instance to extend.</param>
        /// <param name="functOnCatch">Function to map the exception to the new error type.</param>
        /// <returns>A Task of Try with the new error type.</returns>
        public static async Task<Try<S, R, E2>> Catch<S, R, E2>(this Task<Try<S, R, Exception>> tried, Func<S, Exception, E2> functOnCatch)
            => (await tried).Catch(functOnCatch);
    }
}
