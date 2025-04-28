namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {
        public static async Task<Try<S, R, E2>> Catch<S, R, E2>(this Task<Try<S, R, Exception>> tried, Func<S, Exception, E2> functOnCatch)
            => (await tried).Catch(functOnCatch);
    }
}
