namespace FluentFunctionalCoding
{
    public static partial class WhenIsForTasks
    {

        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, bool isTrue)
            => (await whenIs).Is(isTrue);

        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, params Func<bool>[] predicates)
            => (await whenIs).Is(predicates);

        public static async Task<When<T>> IsAsync<T>(this Task<WhenIs<T>> whenIs, params Func<T, bool>[] predicates)
            => (await whenIs).Is(predicates);
    }
}
