namespace FluentCoding
{
    public readonly partial struct SwitchMap<TIn, TOut>
    {

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(_ => predicate, map);
            return this;
        }
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(_ => predicate(), map);
            return this;
        }

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
        {
            _casesByPriority.Add(predicate, map);
            return this;
        }
    }
}
