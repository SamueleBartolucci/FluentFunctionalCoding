using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides methods for binding (flat-mapping) Optional values.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Applies a function to the contained value if present (Some), returning a new Optional of type T.
        /// </summary>
        /// <typeparam name="T">The result type of the bind function.</typeparam>
        /// <param name="bindOnSome">Function to apply if value is present.</param>
        /// <returns>An Optional of type T.</returns>
        [Pure]
        public Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome)
            => this switch
            {
                None<O> => Optional<T>.None(),
                Some<O>(var v) => bindOnSome(v),
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Applies a function if the Optional is None, returning a new Optional of the same type.
        /// </summary>
        /// <param name="bindOnNone">Function to apply if value is absent.</param>
        /// <returns>An Optional of the same type.</returns>
        [Pure]
        public Optional<O> BindNone(Func<Optional<O>> bindOnNone)
             => this switch
             {
                 None<O> => bindOnNone(),
                 Some<O>(var v) => Some(v),
                 _ => throw UnknowOptionalType()
             };
    }
}
