namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> Case<F, TIn, TOut>(this SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, (Outcome<F, TIn> sbj) => sbj.MapSuccess(mapOnSome));

        public static SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> Case<F, TIn, TOut>(this SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), (Outcome<F, TIn> sbj) => sbj.MapSuccess(mapOnSome));

        public static SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> Case<F, TIn, TOut>(this SwitchMap<Outcome<F,TIn>, Outcome<F,TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case((Outcome<F,TIn> sbj) => sbj.Match(predicate, false), sbj => sbj.MapSuccess(mapOnSome));

    }

}
