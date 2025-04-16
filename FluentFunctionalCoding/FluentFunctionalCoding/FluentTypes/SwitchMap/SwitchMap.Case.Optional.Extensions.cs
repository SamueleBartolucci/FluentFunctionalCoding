namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.Map(mapOnSome));

        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.Map(mapOnSome));

        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(sbj => sbj.Match(predicate, () => false), sbj => sbj.Map(mapOnSome));


        //public static SwitchMap<Optional<TIn>,TOut> Case<TIn, TOut>(this SwitchMap<Optional<TIn>, TOut> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
        //  => switchCase.Case(predicate, sbj => sbj.Map(mapOnSome));

        //public static SwitchMap<Optional<TIn>,TOut> Case<TIn, TOut>(this SwitchMap<Optional<TIn>, TOut> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
        //    => switchCase.Case(predicate(), sbj => sbj.Map(mapOnSome));

        //public static SwitchMap<Optional<TIn>,TOut> Case<TIn, TOut>(this SwitchMap<Optional<TIn>, TOut> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
        //    => switchCase.Case((Optional<TIn> sbj) => sbj.Match(predicate, () => false), //WHEN SOME
        //                       (Optional<TIn> sbj) => sbj.Match(mapOnSome, () => default)); //


    }

}
