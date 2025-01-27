
using System;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace FluentCoding
{
   
    public static partial class SwitchMapExtension
    {
        public static async Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase)
        {
            await (subject);
            return new SwitchMap<T, T1>(subject.Result, defaultCase);
        }
    
        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, bool casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate, caseMap);            

        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<bool> casePredicate, Func<TIn, TOut> caseMap)
             => (await switchCase).Case(casePredicate(), caseMap);

        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<TIn, bool> casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate(switchCase.Result._subject), caseMap);

        public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase)
            => (await switchCase).Match();
    }

}
