namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for SwitchMap to handle IEnumerable, List, and IList cases.
    /// </summary>
    public static partial class SwitchMapExtension
    {
        // IEnumerable
        /// <summary>
        /// Adds a case for when any element in the sequence matches the predicate.
        /// </summary>
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
           => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when all elements in the sequence match the predicate.
        /// </summary>
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when the sequence is empty.
        /// </summary>
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the sequence is not empty.
        /// </summary>
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the sequence has the specified count.
        /// </summary>
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, decimal count, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);

        // List
        /// <summary>
        /// Adds a case for when any element in the list matches the predicate.
        /// </summary>
        public static SwitchMap<List<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<List<TIn>, TOut> caseMap)
         => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when all elements in the list match the predicate.
        /// </summary>
        public static SwitchMap<List<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when the list is empty.
        /// </summary>
        public static SwitchMap<List<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the list is not empty.
        /// </summary>
        public static SwitchMap<List<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the list has the specified count.
        /// </summary>
        public static SwitchMap<List<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, decimal count, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);

        // IList
        /// <summary>
        /// Adds a case for when any element in the list matches the predicate.
        /// </summary>
        public static SwitchMap<IList<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IList<TIn>, TOut> caseMap)
         => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when all elements in the list match the predicate.
        /// </summary>
        public static SwitchMap<IList<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        /// <summary>
        /// Adds a case for when the list is empty.
        /// </summary>
        public static SwitchMap<IList<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the list is not empty.
        /// </summary>
        public static SwitchMap<IList<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        /// <summary>
        /// Adds a case for when the list has the specified count.
        /// </summary>
        public static SwitchMap<IList<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, decimal count, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);
    }

}
