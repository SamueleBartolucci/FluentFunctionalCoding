namespace FluentCoding
{
    public partial record SwitchMapBase<TIn, TOut>
    {
        internal readonly TIn _subject;


        public static SwitchMapBase<TIn, TOut> Switch(TIn switchSubject) => new(switchSubject);

        private SwitchMapBase(TIn switchSubject) => (this._subject) = (switchSubject);

        public ISwitchMap<TIn, TOut> Default(Func<TIn, TOut> defaultCase) => SwitchMap<TIn, TOut>.Switch(_subject, defaultCase);

    }
}
