namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Asynchronously binds the Optional value to a new Optional value if present (Some), using the provided function.
        /// </summary>
        /// <typeparam name="O">The type of the value in the source Optional.</typeparam>
        /// <typeparam name="T">The type of the value in the resulting Optional.</typeparam>
        /// <param name="optional">The source Optional wrapped in a Task.</param>
        /// <param name="bindOnSome">Function to apply if value is present.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        public static async Task<Optional<T>> BindAsync<O, T>(this Task<Optional<O>> optional, Func<O, Optional<T>> bindOnSome)
            => (await optional).Bind(bindOnSome);

        /// <summary>
        /// Asynchronously binds the Optional value to a new Optional value if it is None, using the provided function.
        /// </summary>
        /// <typeparam name="O">The type of the value in the source Optional.</typeparam>
        /// <param name="optional">The source Optional wrapped in a Task.</param>
        /// <param name="bindOnNone">Function to apply if value is absent.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        public static async Task<Optional<O>> BindNoneAsync<O>(this Task<Optional<O>> optional, Func<Optional<O>> bindOnNone)
            => (await optional).BindNone(bindOnNone);

        /// <summary>
        /// Asynchronously binds the Optional value to a new Optional value if present (Some), using the provided asynchronous function.
        /// </summary>
        /// <typeparam name="O">The type of the value in the source Optional.</typeparam>
        /// <typeparam name="T">The type of the value in the resulting Optional.</typeparam>
        /// <param name="optional">The source Optional wrapped in a Task.</param>
        /// <param name="bindOnSome">Asynchronous function to apply if value is present.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        public static async Task<Optional<T>> BindAsync<O, T>(this Task<Optional<O>> optional, Func<O, Task<Optional<T>>> bindOnSome)
            => await (await optional).BindAsync(bindOnSome);

        /// <summary>
        /// Asynchronously binds the Optional value to a new Optional value if it is None, using the provided asynchronous function.
        /// </summary>
        /// <typeparam name="O">The type of the value in the source Optional.</typeparam>
        /// <param name="optional">The source Optional wrapped in a Task.</param>
        /// <param name="bindOnNone">Asynchronous function to apply if value is absent.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        public static async Task<Optional<O>> BindNoneAsync<O>(this Task<Optional<O>> optional, Func<Task<Optional<O>>> bindOnNone)
            => await (await optional).BindNoneAsync(bindOnNone);
    }

}
