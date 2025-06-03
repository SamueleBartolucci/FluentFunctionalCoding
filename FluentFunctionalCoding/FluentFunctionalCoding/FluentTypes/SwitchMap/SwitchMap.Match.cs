namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        /// <summary>
        /// Executes the switch mapping and returns the result.
        /// </summary>
        /// <returns>The result of the matched case or the default case.</returns>
        public TOut Match() => this switch
            {
                DefaultCase<TIn, TOut>(var sbj, var defaultMapfunc) => defaultMapfunc(sbj),
                MatchedCase<TIn, TOut>(var sbj, var matchetMapFunc) => matchetMapFunc(sbj),
                _ => throw UnknowOptionalType()
            };
    }
}
