namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        // Dictionary
        public static SwitchMap<Dictionary<TK, TV>, TOut> CaseContainsKey<TK, TV, TOut>(this SwitchMap<Dictionary<TK, TV>, TOut> switchCase, TK key, Func<Dictionary<TK, TV>, TOut> caseMap)
           => switchCase.Case(subject => subject.ContainsKey(key), caseMap);

        public static SwitchMap<Dictionary<TK, TV>, TOut> CaseContains<TK, TV, TOut>(this SwitchMap<Dictionary<TK, TV>, TOut> switchCase, KeyValuePair<TK, TV> item, Func<Dictionary<TK, TV>, TOut> caseMap)
           => switchCase.Case(subject => subject.Contains(item), caseMap);


        // IDictionary
        public static SwitchMap<IDictionary<TK, TV>, TOut> CaseContainsKey<TK, TV, TOut>(this SwitchMap<IDictionary<TK, TV>, TOut> switchCase, TK key, Func<IDictionary<TK, TV>, TOut> caseMap)
           => switchCase.Case(subject => subject.ContainsKey(key), caseMap);

        public static SwitchMap<IDictionary<TK, TV>, TOut> CaseContains<TK, TV, TOut>(this SwitchMap<IDictionary<TK, TV>, TOut> switchCase, KeyValuePair<TK, TV> item, Func<IDictionary<TK, TV>, TOut> caseMap)
           => switchCase.Case(subject => subject.Contains(item), caseMap);

    }

}
