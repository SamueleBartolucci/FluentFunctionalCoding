namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, bool casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate, caseMap);

        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<bool> casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate(), caseMap);

        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<TIn, bool> casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate(((SwitchMap < TIn, TOut >)switchCase.Result)._subject), caseMap);
    }

}
