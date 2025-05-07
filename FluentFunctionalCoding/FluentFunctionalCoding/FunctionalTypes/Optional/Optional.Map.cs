using System.Diagnostics.Contracts;


namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides methods for mapping (transforming) Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Transforms the contained value if present (Some) using the provided function, returning a new Optional of type B.
        /// </summary>
        /// <typeparam name="B">The result type of the map function.</typeparam>
        /// <param name="mapOnSome">Function to apply if value is present.</param>
        /// <returns>An Optional of type B.</returns>
        [Pure]
        public Optional<B> Map<B>(Func<O, B> mapOnSome) =>
            this switch
            {
                None<O> => Optional<B>.None(),
                Some<O>(var v) => Optional<B>.Some(mapOnSome(v)),
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Transforms the Optional if it is None using the provided function, returning a new Optional of the same type.
        /// </summary>
        /// <param name="mapOnNone">Function to generate a value if Optional is None.</param>
        /// <returns>An Optional of the same type.</returns>
        [Pure]
        public Optional<O> MapNone(Func<O> mapOnNone) =>
            this switch
            {
                None<O> => Some(mapOnNone()),
                Some<O>(var v) => Some(v),
                _ => throw UnknowOptionalType()
            };
    }
}
