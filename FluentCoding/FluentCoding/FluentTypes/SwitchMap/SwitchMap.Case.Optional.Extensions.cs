namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static ISwitchMap<Optional<TIn>, Optional<TOut>> Case<TIn, TOut>(this ISwitchMap<Optional<TIn>, Optional<TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.Map(mapOnSome));


        public static ISwitchMap<Optional<TIn>, Optional<TOut>> Case<TIn, TOut>(this ISwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.Map(mapOnSome));

        public static ISwitchMap<Optional<TIn>, Optional<TOut>> Case<TIn, TOut>(this ISwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case((Optional<TIn> sbj) => sbj.Match(predicate, () => false), sbj => sbj.Map(mapOnSome));

    }

}
