namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: SwitchMap<TIn, TOut>
    {

        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, TOut defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, _ => defaultCase);
        public static SwitchMap<TIn, TOut> Switch(TIn switchSubject, Func<TIn, TOut> defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, defaultCase);
    }
}
