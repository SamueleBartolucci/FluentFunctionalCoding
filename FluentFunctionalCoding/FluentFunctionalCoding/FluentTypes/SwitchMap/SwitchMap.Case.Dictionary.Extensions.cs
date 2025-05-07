namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for SwitchMap to handle Dictionary and IDictionary cases.
    /// </summary>
    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Adds a case for when the dictionary contains the specified key.
        /// </summary>
        public static SwitchMap<Dictionary<TK, TV>, TOut> CaseContainsKey<TK, TV, TOut>(this SwitchMap<Dictionary<TK, TV>, TOut> switchCase, TK key, Func<Dictionary<TK, TV>, TOut> caseMap)
             where TK : notnull
           => switchCase.Case(subject => subject.ContainsKey(key), caseMap);

        /// <summary>
        /// Adds a case for when the dictionary contains the specified key-value pair.
        /// </summary>
        public static SwitchMap<Dictionary<TK, TV>, TOut> CaseContains<TK, TV, TOut>(this SwitchMap<Dictionary<TK, TV>, TOut> switchCase, KeyValuePair<TK, TV> item, Func<Dictionary<TK, TV>, TOut> caseMap)
             where TK : notnull
           => switchCase.Case(subject => subject.Contains(item), caseMap);

        /// <summary>
        /// Adds a case for when the IDictionary contains the specified key.
        /// </summary>
        public static SwitchMap<IDictionary<TK, TV>, TOut> CaseContainsKey<TK, TV, TOut>(this SwitchMap<IDictionary<TK, TV>, TOut> switchCase, TK key, Func<IDictionary<TK, TV>, TOut> caseMap)
             where TK : notnull
           => switchCase.Case(subject => subject.ContainsKey(key), caseMap);

        /// <summary>
        /// Adds a case for when the IDictionary contains the specified key-value pair.
        /// </summary>
        public static SwitchMap<IDictionary<TK, TV>, TOut> CaseContains<TK, TV, TOut>(this SwitchMap<IDictionary<TK, TV>, TOut> switchCase, KeyValuePair<TK, TV> item, Func<IDictionary<TK, TV>, TOut> caseMap)
             where TK : notnull
           => switchCase.Case(subject => subject.Contains(item), caseMap);

    }

}
