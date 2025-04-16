namespace FluentFunctionalCoding
{
    public partial record PredicateMatchCase<TIn, TOut> : SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;        
        internal Func<TIn, TOut> _defaultCaseFunc = null;

        internal PredicateMatchCase(TIn subject, Func<TIn, TOut> defaultCaseFunc) => (_subject, _defaultCaseFunc) = (subject, defaultCaseFunc);

        internal void Deconstruct(out TIn value, out Func<TIn, TOut> defaultCaseFunc) => (value, defaultCaseFunc) = (_subject, _defaultCaseFunc);

    }
}
