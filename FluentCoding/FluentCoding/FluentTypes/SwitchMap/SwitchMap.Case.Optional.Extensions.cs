namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static ISwitchMap<IOptional<TIn>, IOptional<TOut>> Case<TIn, TOut>(this ISwitchMap<IOptional<TIn>, IOptional<TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.Map(mapOnSome));


        public static ISwitchMap<IOptional<TIn>, IOptional<TOut>> Case<TIn, TOut>(this ISwitchMap<IOptional<TIn>, IOptional<TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.Map(mapOnSome));

        public static ISwitchMap<IOptional<TIn>, IOptional<TOut>> Case<TIn, TOut>(this ISwitchMap<IOptional<TIn>, IOptional<TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(sbj => sbj.Match(predicate, () => false), sbj => sbj.Map(mapOnSome));

    }

}
