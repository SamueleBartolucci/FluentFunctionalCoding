namespace FluentCoding
{
    public readonly partial struct SwitchMap<TIn, TOut>
    {
        internal readonly TIn _subject;
        internal readonly Func<TIn, TOut> _defaultCase = null;
        internal readonly Dictionary<Func<TIn, bool>, Func<TIn, TOut>> _casesByPriority = new ();

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new(switchSubject, _ => defaultCase);

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new(switchSubject, defaultCase);


        private SwitchMap(TIn switchSubject) => this._subject = switchSubject;

        private SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase) : this(switchSubject)
            => this._defaultCase = defaultCase;

    }
}
