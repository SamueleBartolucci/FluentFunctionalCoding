namespace FluentFunctionalCoding
{

    public partial record SwitchMap<TIn, TOut> //: ISwitchMap<TIn, TOut>
    {        
        private SwitchMap<TIn, TOut> CheckAndSelectMapFunction(bool predicateValue, Func<TIn, TOut> mapFunc)
        {            
            if (!_validPredicatFound && predicateValue)
            {
                //newMap = this with { _validPredicatFound = true, _defaultOrSelectedMapFunction = mapFunc };
                _defaultOrSelectedMapFunction = mapFunc;
                _validPredicatFound = true;
            }
            return this;
        }

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
            => CheckAndSelectMapFunction(predicate, map);

        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
            => (!_validPredicatFound)? CheckAndSelectMapFunction(predicate(), map) : this;

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map) 
            => (!_validPredicatFound) ? CheckAndSelectMapFunction(predicate(_subject), map) : this;
    }
}
