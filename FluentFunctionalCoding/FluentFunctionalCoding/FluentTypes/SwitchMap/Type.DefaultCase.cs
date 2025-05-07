namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents the default case in a SwitchMap operation.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    public partial record DefaultCase<TIn, TOut> : SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;        
        internal Func<TIn, TOut> _defaultCaseFunc = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCase{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="subject">The subject value.</param>
        /// <param name="defaultCaseFunc">The default case function.</param>
        internal DefaultCase(TIn subject, Func<TIn, TOut> defaultCaseFunc) => (_subject, _defaultCaseFunc) = (subject, defaultCaseFunc);

        /// <summary>
        /// Deconstructs the DefaultCase into its value and default case function.
        /// </summary>
        /// <param name="value">The subject value.</param>
        /// <param name="defaultCaseFunc">The default case function.</param>
        internal void Deconstruct(out TIn value, out Func<TIn, TOut> defaultCaseFunc) => (value, defaultCaseFunc) = (_subject, _defaultCaseFunc);

    }
}
