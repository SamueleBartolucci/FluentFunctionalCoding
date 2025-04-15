namespace FluentFunctionalCoding
{
    public partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;
        internal bool _validPredicatFound = false;
        internal Func<TIn, TOut> _defaultOrSelectedMapFunction = null;


        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new SwitchMap<TIn, TOut>(switchSubject, _ => defaultCase);        

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new SwitchMap<TIn, TOut>(switchSubject, defaultCase);

        private SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase)
            => (this._subject, this._defaultOrSelectedMapFunction) = (switchSubject, defaultCase);

    }
}
