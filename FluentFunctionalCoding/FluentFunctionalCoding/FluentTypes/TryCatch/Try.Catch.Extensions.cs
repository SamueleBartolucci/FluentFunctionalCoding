namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {
        /// <summary>
        /// Adds a custom catch handler to a Try, mapping the exception to a new error type.
        /// </summary>
        /// <typeparam name="Tin">The input type.</typeparam>
        /// <typeparam name="TOut">The output type.</typeparam>
        /// <typeparam name="E2">The new error type.</typeparam>
        /// <param name="tried">The Try instance to extend.</param>
        /// <param name="functOnCatch">Function to map the exception to the new error type.</param>
        /// <returns>A Try with the new error type.</returns>
        public static Try<Tin, TOut, E2> Catch<Tin, TOut, E2>(this Try<Tin, TOut, Exception> tried, Func<Tin, Exception, E2> functOnCatch)
            => tried switch
            {
                Success<Tin, TOut, Exception>(var s, var r) => new Success<Tin, TOut, E2>(s, r),
                Failure<Tin, TOut, Exception>(var s, var r, var ex) => new Failure<Tin, TOut, E2>(s, functOnCatch(s, ex), ex),
                _ => throw Try<Tin, TOut, E2>.UnknowImplementation()
            };
    }
}
