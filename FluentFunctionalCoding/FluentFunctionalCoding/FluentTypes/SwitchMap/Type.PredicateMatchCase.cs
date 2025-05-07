namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a case in a SwitchMap operation where a predicate matched.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    public partial record PredicateMatchCase<TIn, TOut> : SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;        
        internal Func<TIn, TOut> _defaultCaseFunc = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateMatchCase{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="subject">The subject value.</param>
        /// <param name="defaultCaseFunc">The function to execute for the matched case.</param>
        internal PredicateMatchCase(TIn subject, Func<TIn, TOut> defaultCaseFunc) => (_subject, _defaultCaseFunc) = (subject, defaultCaseFunc);

        /// <summary>
        /// Deconstructs the PredicateMatchCase into its value and matched case function.
        /// </summary>
        /// <param name="value">The subject value.</param>
        /// <param name="defaultCaseFunc">The matched case function.</param>
        internal void Deconstruct(out TIn value, out Func<TIn, TOut> defaultCaseFunc) => (value, defaultCaseFunc) = (_subject, _defaultCaseFunc);

    }
}
