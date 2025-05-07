namespace FluentFunctionalCoding
{
    /// <summary>
    /// Defines a fluent interface for switch mapping operations.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    public interface ISwitchMap<out TIn, TOut>
    {
        /// <summary>
        /// Adds a case with a boolean predicate and a mapping function.
        /// </summary>
        ISwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map);

        /// <summary>
        /// Adds a case with a predicate function and a mapping function.
        /// </summary>
        ISwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map);

        /// <summary>
        /// Adds a case with a predicate function that takes the input and a mapping function.
        /// </summary>
        ISwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map);

        /// <summary>
        /// Executes the switch mapping and returns the result.
        /// </summary>
        TOut Match();        
    }

}
