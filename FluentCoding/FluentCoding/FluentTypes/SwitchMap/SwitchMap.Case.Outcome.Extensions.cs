namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> Case<F, TIn, TOut>(this ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.MapSuccess(mapOnSome));

        public static ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> Case<F, TIn, TOut>(this ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.MapSuccess(mapOnSome));

        public static ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> Case<F, TIn, TOut>(this ISwitchMap<IOutcome<F, TIn>, IOutcome<F, TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(sbj => sbj.Match(predicate, false), sbj => sbj.MapSuccess(mapOnSome));

    }

}
