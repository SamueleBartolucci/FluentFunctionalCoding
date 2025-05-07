namespace FluentFunctionalCoding
{
    public static partial class SwitchMapExtension
    {
        /// <summary>
        /// Asynchronously executes the switch mapping and returns the result.
        /// </summary>
        /// <typeparam name="TIn">The input type.</typeparam>
        /// <typeparam name="TOut">The output type.</typeparam>
        /// <param name="switchCase">A Task representing the SwitchMap instance.</param>
        /// <returns>A Task representing the asynchronous operation, with the result of the matched case or the default case.</returns>
        public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase)
            => (await switchCase).Match();
    }

}
