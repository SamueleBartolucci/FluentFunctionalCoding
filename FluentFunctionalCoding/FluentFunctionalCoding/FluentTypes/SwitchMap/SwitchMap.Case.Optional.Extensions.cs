namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for SwitchMap to handle Optional cases.
    /// </summary>
    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Adds a case for when the Optional contains a value and the predicate is true.
        /// </summary>
        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.Map(mapOnSome));

        /// <summary>
        /// Adds a case for when the Optional contains a value and the predicate function returns true.
        /// </summary>
        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.Map(mapOnSome));

        /// <summary>
        /// Adds a case for when the Optional contains a value and the predicate function returns true for the value.
        /// </summary>
        public static SwitchMap<Optional<TIn>, Optional<TOut>> CaseOptional<TIn, TOut>(this SwitchMap<Optional<TIn>, Optional<TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(sbj => sbj.Match(predicate, () => false), sbj => sbj.Map(mapOnSome));
    }

}
