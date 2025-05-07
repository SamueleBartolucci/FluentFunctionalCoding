namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: ISwitchMap<TIn, TOut>
    {        
        /// <summary>
        /// Checks the predicate and selects the appropriate map function.
        /// </summary>
        /// <param name="isPredicateTrue">Indicates if the predicate is true.</param>
        /// <param name="mapFunc">The mapping function to use if the predicate is true.</param>
        /// <returns>A new SwitchMap if the predicate is true, otherwise the current instance.</returns>
        private SwitchMap<TIn, TOut> CheckAndSelectMapFunction(bool isPredicateTrue, Func<TIn, TOut> mapFunc)
        {            
            return this switch
            {
                DefaultCase<TIn, TOut> (TIn sbj, _) when isPredicateTrue => new PredicateMatchCase<TIn, TOut>(sbj, mapFunc),
                var noChangeOfState => noChangeOfState
            };
        }       

        /// <summary>
        /// Adds a case with a boolean predicate and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
            => CheckAndSelectMapFunction(predicate, map);

        /// <summary>
        /// Adds a case with a predicate function and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
            => (this is DefaultCase<TIn, TOut>) ? CheckAndSelectMapFunction(predicate(), map) : this;

        /// <summary>
        /// Adds a case with a predicate function that takes the input and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
           => (this is DefaultCase<TIn, TOut>(var sbj, _)) ? CheckAndSelectMapFunction(predicate(sbj), map) : this;
    }
}
