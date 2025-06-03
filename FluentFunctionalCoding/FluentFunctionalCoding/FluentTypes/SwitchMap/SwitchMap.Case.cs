namespace FluentFunctionalCoding
{
    public abstract partial record SwitchMap<TIn, TOut> //: ISwitchMap<TIn, TOut>
    {     
        /// <summary>
        /// Adds a case with a boolean predicate and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(bool predicate, Func<TIn, TOut> map)
             => this switch
             {
                 DefaultCase<TIn, TOut>(var sbj, _) when predicate => new MatchedCase<TIn, TOut>(sbj, map),
                 var noChangeOfState => noChangeOfState
             };


        /// <summary>
        /// Adds a case with a predicate function and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(Func<bool> predicate, Func<TIn, TOut> map)
            => this switch
            {
                DefaultCase<TIn, TOut>(var sbj, _) when predicate() => new MatchedCase<TIn, TOut>(sbj, map),
                var noChangeOfState => noChangeOfState
            };

        /// <summary>
        /// Adds a case with a predicate function that takes the input and a mapping function.
        /// </summary>
        public SwitchMap<TIn, TOut> Case(Func<TIn, bool> predicate, Func<TIn, TOut> map)
           => this switch
            {                
                DefaultCase<TIn, TOut>(var sbj, _) when predicate(sbj) => new MatchedCase<TIn, TOut>(sbj, map),
                var noChangeOfState => noChangeOfState
            };
}
}
