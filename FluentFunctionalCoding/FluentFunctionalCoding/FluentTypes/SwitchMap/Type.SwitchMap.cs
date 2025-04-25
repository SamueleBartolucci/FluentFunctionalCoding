namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(DefaultCase<TIn, TOut>)} or {nameof(PredicateMatchCase<TIn, TOut>)}");        
    }
}
