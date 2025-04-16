namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        internal static NotImplementedException UnknowOptionalType() => new NotImplementedException($"Unknown type, expected: {nameof(DefaultCase<TIn, TOut>)} or {nameof(PredicateMatchCase<TIn, TOut>)}");
        //internal readonly TIn _subject;
        //internal bool _validPredicatFound = false;
        //internal Func<TIn, TOut> _defaultOrSelectedMapFunction = null;


        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, _ => defaultCase);        

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, defaultCase);

        //private SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase)
        //    => (this._subject, this._defaultOrSelectedMapFunction) = (switchSubject, defaultCase);

    }
}
