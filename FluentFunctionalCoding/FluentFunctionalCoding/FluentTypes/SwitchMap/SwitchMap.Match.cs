namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        public TOut Match() => this switch
            {
                DefaultCase<TIn, TOut>(var sbj, var defaultMapfunc) => defaultMapfunc(sbj),
                PredicateMatchCase<TIn, TOut>(var sbj, var matchetMapFunc) => matchetMapFunc(sbj),
                _ => throw UnknowOptionalType()
            };
}
}
