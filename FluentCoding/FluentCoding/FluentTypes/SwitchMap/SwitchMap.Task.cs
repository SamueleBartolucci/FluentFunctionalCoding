
using System;

namespace FluentCoding
{
    public static class SwitchMapExtension
    {
        //internal static SwitchMap<Task<TIn>, TOut> Switch<TIn, TOut>(this SwitchMap<Task<TIn>, TOut> switchCase, Func<TIn, TOut> defaultPredicate)
        //{
        //    switchCase.DefaultCase = switchSubject => defaultPredicate(switchSubject.Result);
        //    return switchCase;
        //}

        internal static SwitchMap<Task<TIn>, TOut> Case<TIn, TOut>(this SwitchMap<Task<TIn>, TOut> switchCase, bool casePredicate, Func<TIn, TOut> caseMap)
        {
            switchCase.CasesByPriority.Add(switchSubject => casePredicate, switchSubject => caseMap(switchSubject.Result));
            return switchCase;
        }

        internal static SwitchMap<Task<TIn>, TOut> Case<TIn, TOut>(this SwitchMap<Task<TIn>, TOut> switchCase, Func<bool> casePredicate, Func<TIn, TOut> caseMap)
            => switchCase.Case(_ => casePredicate(), switchSubject => caseMap(switchSubject.Result));

        internal static SwitchMap<Task<TIn>, TOut> Case<TIn, TOut>(this SwitchMap<Task<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<TIn, TOut> caseMap)
            => switchCase.Case(switchSubject => casePredicate(switchSubject.Result), switchSubject => caseMap(switchSubject.Result));

        internal static async Task<TOut> MatchAsync<TIn, TOut>(this SwitchMap<Task<TIn>, TOut> switchCase)
        {
            await switchCase.SwitchSubject;
            return switchCase.Match(switchCase.SwitchSubject);
        }
    }

}
