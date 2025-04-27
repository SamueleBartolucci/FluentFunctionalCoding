namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        public static SwitchMapBase<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject) => new SwitchMapBase<TIn, TOut>(switchSubject);
        public static SwitchMap<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject, TOut defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, _ => defaultCase);
        public static SwitchMap<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject, Func<TIn, TOut> defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, defaultCase);


        public static async Task<SwitchMap<T, T1>> Switch<T, T1>(Task<T> subject, Func<T, T1> defaultCase)
        {
            await (subject);
            return Prelude.Switch(subject.Result, defaultCase);
        }

        public static async Task<SwitchMap<T, T1>> Switch<T, T1>(Task<T> subject, T1 defaultCase)
        {
            await (subject);
            return Prelude.Switch(subject.Result, defaultCase);
        }
    }
}


