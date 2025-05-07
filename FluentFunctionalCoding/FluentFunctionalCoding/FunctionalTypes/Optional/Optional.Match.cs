using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides pattern matching methods for Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Returns the result of <paramref name="mapOnNone"/> if Optional is None; otherwise returns the contained value.
        /// </summary>
        /// <param name="mapOnNone">Function to generate a value if Optional is None.</param>
        /// <returns>The contained value or the result of mapOnNone.</returns>
        [Pure]
        public O MatchNone(Func<O> mapOnNone)
            => this switch
            {
                None<O> => mapOnNone(),
                Some<O>(var v) => v,
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Returns <paramref name="valueWhenNone"/> if Optional is None; otherwise returns the contained value.
        /// </summary>
        /// <param name="valueWhenNone">Value to return if Optional is None.</param>
        /// <returns>The contained value or valueWhenNone.</returns>
        [Pure]
        public O MatchNone(O valueWhenNone)
            => this switch
            {
                None<O> => valueWhenNone,
                Some<O>(var v) => v,
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Matches on Some/None, returning the result of the appropriate function.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <param name="mapOnNone">Function to apply if value is absent.</param>
        /// <returns>The result of the appropriate function.</returns>
        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone)
             => this switch
             {
                 None<O> => mapOnNone(),
                 Some<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };

        /// <summary>
        /// Matches on Some/None, returning the result of the appropriate function or value.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <param name="valueOnNone">Value to return if value is absent.</param>
        /// <returns>The result of the function or value.</returns>
        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, T valueOnNone)
             => this switch
             {
                 None<O> => valueOnNone,
                 Some<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };
    }
}
