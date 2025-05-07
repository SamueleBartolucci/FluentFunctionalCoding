namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents the base class for a fluent switch mapping operation.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    public partial record SwitchMapBase<TIn, TOut>
    {
        internal readonly TIn _subject;        

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchMapBase{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="switchSubject">The subject to switch on.</param>
        internal SwitchMapBase(TIn switchSubject) => (this._subject) = (switchSubject);

        /// <summary>
        /// Defines the default case for the switch operation.
        /// </summary>
        /// <param name="defaultCase">The function to execute for the default case.</param>
        /// <returns>A SwitchMap instance with the default case.</returns>
        public SwitchMap<TIn, TOut> Default(Func<TIn, TOut> defaultCase) => Prelude.Switch(_subject, defaultCase);

    }
}
