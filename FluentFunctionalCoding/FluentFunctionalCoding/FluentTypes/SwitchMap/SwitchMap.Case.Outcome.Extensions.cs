namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for SwitchMap to handle Outcome cases.
    /// </summary>
    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Adds a case for when the Outcome is successful and the predicate is true.
        /// </summary>
        public static SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> CaseOutcome<F, TIn, TOut>(this SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> switchCase, bool predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate, sbj => sbj.MapSuccess(mapOnSome));

        /// <summary>
        /// Adds a case for when the Outcome is successful and the predicate function returns true.
        /// </summary>
        public static SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> CaseOutcome<F, TIn, TOut>(this SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> switchCase, Func<bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(predicate(), sbj => sbj.MapSuccess(mapOnSome));

        /// <summary>
        /// Adds a case for when the Outcome is successful and the predicate function returns true for the value.
        /// </summary>
        public static SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> CaseOutcome<F, TIn, TOut>(this SwitchMap<Outcome<F, TIn>, Outcome<F, TOut>> switchCase, Func<TIn, bool> predicate, Func<TIn, TOut> mapOnSome)
            => switchCase.Case(sbj => sbj.Match(predicate, false), sbj => sbj.MapSuccess(mapOnSome));
    }

}
