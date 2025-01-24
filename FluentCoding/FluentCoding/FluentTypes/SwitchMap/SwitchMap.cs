namespace FluentCoding
{
    public struct SwitchMap<TIn, TOut>
    {
        internal TIn SwitchSubject { get; set; }
        internal Func<TIn, TOut> DefaultCase = null;
        internal Dictionary<Func<TIn, bool>, Func<TIn, TOut>> CasesByPriority = new Dictionary<Func<TIn, bool>, Func<TIn, TOut>>();

        private SwitchMap(TIn switchSubject) => this.SwitchSubject = switchSubject;

        public SwitchMap(TIn switchSubject, Func<TIn, TOut> defaultCase) : this(switchSubject)
            => this.DefaultCase = defaultCase;

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
        {
            CasesByPriority.Add(_ => predicate, map);
            return this;
        }
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
        {
            CasesByPriority.Add(_ => predicate(), map);
            return this;
        }

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
        {
            CasesByPriority.Add(predicate, map);
            return this;
        }

        public TOut Match() => Match(SwitchSubject);

        internal TOut Match(TIn switchSubjectg)
        {            
            var matchCase = CasesByPriority.FirstOrDefault(testCase => testCase.Key(switchSubjectg));
            return matchCase.Value(switchSubjectg) ?? DefaultCase(switchSubjectg);
        }
    }
}
