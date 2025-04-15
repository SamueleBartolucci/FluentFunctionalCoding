namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        // IEnumerable
        public static SwitchMap<IEnumerable<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
           => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        public static SwitchMap<IEnumerable<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        public static SwitchMap<IEnumerable<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        public static SwitchMap<IEnumerable<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        public static SwitchMap<IEnumerable<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<IEnumerable<TIn>, TOut> switchCase, decimal count, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);


        // List
        public static SwitchMap<List<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<List<TIn>, TOut> caseMap)
         => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        public static SwitchMap<List<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        public static SwitchMap<List<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        public static SwitchMap<List<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        public static SwitchMap<List<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<List<TIn>, TOut> switchCase, decimal count, Func<List<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);

        // IList
        public static SwitchMap<IList<TIn>, TOut> CaseAny<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IList<TIn>, TOut> caseMap)
         => switchCase.Case(subject => subject.Any(casePredicate), caseMap);

        public static SwitchMap<IList<TIn>, TOut> CaseAll<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        public static SwitchMap<IList<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        public static SwitchMap<IList<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        public static SwitchMap<IList<TIn>, TOut> CaseCount<TIn, TOut>(this SwitchMap<IList<TIn>, TOut> switchCase, decimal count, Func<IList<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);
    }

}
