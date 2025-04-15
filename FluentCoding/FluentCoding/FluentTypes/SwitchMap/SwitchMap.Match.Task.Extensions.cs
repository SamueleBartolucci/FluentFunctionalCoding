namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<SwitchMap<TIn, TOut>> switchCase)
            => (await switchCase).Match();
    }

}
