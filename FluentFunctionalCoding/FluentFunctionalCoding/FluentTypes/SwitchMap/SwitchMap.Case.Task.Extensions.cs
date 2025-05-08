namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Adds a case to the asynchronous SwitchMap with a boolean predicate and a mapping function.
        /// </summary>
        /// <typeparam name="TIn">The input type.</typeparam>
        /// <typeparam name="TOut">The output type.</typeparam>
        /// <param name="switchCase">The asynchronous SwitchMap instance.</param>
        /// <param name="casePredicate">The boolean predicate for the case.</param>
        /// <param name="caseMap">The mapping function to apply if the predicate matches.</param>
        /// <returns>A task representing the asynchronous SwitchMap with the new case added.</returns>
        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, bool casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate, caseMap);

        /// <summary>
        /// Adds a case to the asynchronous SwitchMap with a predicate function and a mapping function.
        /// </summary>
        /// <typeparam name="TIn">The input type.</typeparam>
        /// <typeparam name="TOut">The output type.</typeparam>
        /// <param name="switchCase">The asynchronous SwitchMap instance.</param>
        /// <param name="casePredicate">The predicate function for the case.</param>
        /// <param name="caseMap">The mapping function to apply if the predicate matches.</param>
        /// <returns>A task representing the asynchronous SwitchMap with the new case added.</returns>
        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<bool> casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate, caseMap);

        /// <summary>
        /// Adds a case to the asynchronous SwitchMap with an input-based predicate and a mapping function.
        /// </summary>
        /// <typeparam name="TIn">The input type.</typeparam>
        /// <typeparam name="TOut">The output type.</typeparam>
        /// <param name="switchCase">The asynchronous SwitchMap instance.</param>
        /// <param name="casePredicate">The input-based predicate function for the case.</param>
        /// <param name="caseMap">The mapping function to apply if the predicate matches.</param>
        /// <returns>A task representing the asynchronous SwitchMap with the new case added.</returns>
        public static async Task<SwitchMap<TIn, TOut>> CaseAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase, Func<TIn, bool> casePredicate, Func<TIn, TOut> caseMap)
            => (await switchCase).Case(casePredicate, caseMap);
    }

}
