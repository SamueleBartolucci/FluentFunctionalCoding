namespace FluentCoding
{
    public partial record SwitchMap<TIn, TOut> : ISwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;
        internal bool _validPredicatFound = false;
        internal Func<TIn, TOut> _defaultOrSelectedMapFunction = null;


        public static ISwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new SwitchMap<TIn, TOut>(switchSubject, _ => defaultCase);        

        public static ISwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new SwitchMap<TIn, TOut>(switchSubject, defaultCase);

        private SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase)
            => (this._subject, this._defaultOrSelectedMapFunction) = (switchSubject, defaultCase);

    }
}
