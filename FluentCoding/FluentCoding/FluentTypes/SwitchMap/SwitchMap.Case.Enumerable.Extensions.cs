namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static ISwitchMap<IEnumerable<TIn>, TOut> CaseAny<TIn, TOut>(this ISwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
           => switchCase.Case(subject => subject.Any(casePredicate), caseMap);


        public static ISwitchMap<IEnumerable<TIn>, TOut> CaseAll<TIn, TOut>(this ISwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<TIn, bool> casePredicate, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.All(casePredicate), caseMap);

        public static ISwitchMap<IEnumerable<TIn>, TOut> CaseIsEmpty<TIn, TOut>(this ISwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => !subject.Any(), caseMap);

        public static ISwitchMap<IEnumerable<TIn>, TOut> CaseIsNotEmpty<TIn, TOut>(this ISwitchMap<IEnumerable<TIn>, TOut> switchCase, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Any(), caseMap);

        public static ISwitchMap<IEnumerable<TIn>, TOut> CaseCount<TIn, TOut>(this ISwitchMap<IEnumerable<TIn>, TOut> switchCase, decimal count, Func<IEnumerable<TIn>, TOut> caseMap)
            => switchCase.Case(subject => subject.Count() == count, caseMap);
    }

}
