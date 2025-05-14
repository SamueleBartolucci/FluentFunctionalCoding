using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {

        /// <summary>
        /// Asynchronously binds the current Optional value to a new Optional value if it is present (Some), using the provided asynchronous function.
        /// </summary>
        /// <typeparam name="T">The type of the value in the resulting Optional.</typeparam>
        /// <param name="bindAsyncOnSome">An asynchronous function to bind the value if present.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        [Pure]
        public async Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome)
             => this switch
             {
                 None<O> => Optional<T>.None(),
                 Some<O>(var v) => await bindAsyncOnSome(v),
                 _ => throw UnknowOptionalType()
             };

        /// <summary>
        /// Asynchronously binds the current Optional value to a new Optional value if it is not present (None), using the provided asynchronous function.
        /// </summary>
        /// <param name="bindAsyncOnNone">An asynchronous function to bind if the value is not present.</param>
        /// <returns>A Task containing the resulting Optional value.</returns>
        [Pure]
        public async Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone)
            => this switch
            {
                None<O> => await bindAsyncOnNone(),
                Some<O>(var v) => Some(v),
                _ => throw UnknowOptionalType()
            };
    }
}
