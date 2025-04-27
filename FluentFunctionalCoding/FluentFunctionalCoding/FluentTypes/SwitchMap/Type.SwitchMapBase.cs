namespace FluentFunctionalCoding
{
    public partial record SwitchMapBase<TIn, TOut>
    {
        internal readonly TIn _subject;        

        internal SwitchMapBase(TIn switchSubject) => (this._subject) = (switchSubject);

        public SwitchMap<TIn, TOut> Default(Func<TIn, TOut> defaultCase) => Prelude.Switch(_subject, defaultCase);

    }
}
