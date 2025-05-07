namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a fluent switch mapping operation with cases and matching logic.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    public abstract partial record SwitchMap<TIn, TOut>
    {
        /// <summary>
        /// Throws an exception for unknown optional types.
        /// </summary>
        /// <returns>A NotImplementedException.</returns>
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(DefaultCase<TIn, TOut>)} or {nameof(PredicateMatchCase<TIn, TOut>)}");        
    }
}
