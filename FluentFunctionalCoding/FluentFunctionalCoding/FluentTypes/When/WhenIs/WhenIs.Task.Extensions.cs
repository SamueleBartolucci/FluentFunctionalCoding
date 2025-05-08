namespace FluentFunctionalCoding
{
    public static partial class WhenIsForTasks
    {

        /// <summary>
        /// Asynchronously evaluates a boolean condition on the awaited <see cref="WhenIs{T}"/> and returns a <see cref="When{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="whenIs">A task that returns a <see cref="WhenIs{T}"/> instance.</param>
        /// <param name="isTrue">A boolean value indicating the condition to evaluate.</param>
        /// <returns>A task that returns a <see cref="When{T}"/> based on the evaluated condition.</returns>
        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, bool isTrue)
            => (await whenIs).Is(isTrue);

        /// <summary>
        /// Asynchronously evaluates one or more boolean predicates on the awaited <see cref="WhenIs{T}"/> and returns a <see cref="When{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="whenIs">A task that returns a <see cref="WhenIs{T}"/> instance.</param>
        /// <param name="predicates">An array of boolean predicates to evaluate.</param>
        /// <returns>A task that returns a <see cref="When{T}"/> based on the evaluated predicates.</returns>
        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, params Func<bool>[] predicates)
            => (await whenIs).Is(predicates);

        /// <summary>
        /// Asynchronously evaluates one or more predicates on the awaited <see cref="WhenIs{T}"/> using the subject and returns a <see cref="When{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="whenIs">A task that returns a <see cref="WhenIs{T}"/> instance.</param>
        /// <param name="predicates">An array of predicates that take the subject as input and return a boolean.</param>
        /// <returns>A task that returns a <see cref="When{T}"/> based on the evaluated predicates.</returns>
        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, params Func<T, bool>[] predicates)
            => (await whenIs).Is(predicates);
    }
}
