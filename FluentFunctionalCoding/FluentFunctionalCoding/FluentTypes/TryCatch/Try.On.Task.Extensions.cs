namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {
        public static async Task<Try<TIn, TOut, TErr>> OnFail<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Action<TIn, TErr> actionOnError)
            => (await tried).OnFail(actionOnError);

        public static async Task<Try<TIn, TOut, TErr>> OnFail<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Action<TIn> doOnsubjectWhenOnError)
            => (await tried).OnFail(doOnsubjectWhenOnError);

        public static async Task<Try<TIn, TOut, TErr>> OnSuccess<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Action<TIn, TOut> actionOnSuccess)
            => (await tried).OnSuccess(actionOnSuccess);

        public static async Task<Try<TIn, TOut, TErr>> OnSuccess<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Action<TOut> doOnResultWhenOnSuccess)
            => (await tried).OnSuccess(doOnResultWhenOnSuccess);

    }
}
