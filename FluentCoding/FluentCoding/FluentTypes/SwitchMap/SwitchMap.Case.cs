namespace FluentFunctionalCoding
{

    public abstract partial record SwitchMap<TIn, TOut> //: ISwitchMap<TIn, TOut>
    {        
        private SwitchMap<TIn, TOut> CheckAndSelectMapFunction(bool isPredicateTrue, Func<TIn, TOut> mapFunc)
        {            
            return this switch
            {
                DefaultCase<TIn, TOut> (TIn sbj, _) when isPredicateTrue => new PredicateMatchCase<TIn, TOut>(sbj, mapFunc),
                var noChangeOfState => noChangeOfState
            };
        }       

        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
            => CheckAndSelectMapFunction(predicate, map);

        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
            => (this is DefaultCase<TIn, TOut>) ? CheckAndSelectMapFunction(predicate(), map) : this;

        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
           => (this is DefaultCase<TIn, TOut>(var sbj, _)) ? CheckAndSelectMapFunction(predicate(sbj), map) : this;
    }
}
