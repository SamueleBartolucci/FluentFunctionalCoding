namespace FluentCoding
{

    public partial record SwitchMap<TIn, TOut> : ISwitchMap<TIn, TOut>
    {
        
        private void CheckAndSelectMapFunction(bool predicateValue, Func<TIn, TOut> mapFunc)
        {
            if (!_validPredicatFound && predicateValue)
            {
                _defaultOrSelectedMapFunction = mapFunc;
                _validPredicatFound = true;
            }
        }

        public ISwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
        {
            CheckAndSelectMapFunction(predicate, map);
            return this;
        }
        public ISwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
        {
            if(!_validPredicatFound)
                CheckAndSelectMapFunction(predicate(), map);
            return this;
        }

        public ISwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
        {
            if (!_validPredicatFound)
                CheckAndSelectMapFunction(predicate(_subject), map);
            return this;
        }
    }
}
