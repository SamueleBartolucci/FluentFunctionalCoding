namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents an optional value that may or may not contain a value of type <typeparamref name="O"/>.
    /// Provides methods to perform actions or transformations when a value is present (Some) or absent (None).
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Applies a set of actions to the contained value if present (IsSome), then returns the Optional.
        /// </summary>
        /// <param name="actionsToApplyOnSubject">Actions to apply to the contained value.</param>
        /// <returns>The original Optional instance.</returns>
        public Optional<O> Do(params Action<O>[] actionsToApplyOnSubject)
        {
            if (this is Some<O>(var v))
                v.Do(actionsToApplyOnSubject);

            return this;
        }

        /// <summary>
        /// Applies a set of functions to the contained value if present (IsSome), then returns the Optional. The results of the functions are discarded.
        /// </summary>
        /// <typeparam name="K">The return type of the functions (ignored).</typeparam>
        /// <param name="functionsToApplyOnSubject">Functions to apply to the contained value.</param>
        /// <returns>The original Optional instance.</returns>
        public Optional<O> Do<K>(params Func<O, K>[] functionsToApplyOnSubject)
        {
            if (this is Some<O>(var v))
                v.Do(functionsToApplyOnSubject);

            return this;
        }
    }
}
