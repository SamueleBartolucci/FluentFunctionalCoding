namespace FluentCoding
{
    public partial struct SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;        
        internal bool _truePredicateNotFound = true;        
        internal Func<TIn, TOut> _defaultOrSelectedMapFunction = null;


        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new(switchSubject, _ => defaultCase);

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new(switchSubject, defaultCase);

        private SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase)
            => (this._subject, this._defaultOrSelectedMapFunction) = (switchSubject, defaultCase);

    }
}
