namespace FluentCoding
{
    public static partial class TryExtension
    {
        public static async Task<Try<S, R, E>> OnFail<S, R, E>(this Task<Try<S, R, E>> tried, Action<S, E> actionOnError)
            => (await tried).OnFail(actionOnError);

        public static async Task<Try<S, R, E>> OnFail<S, R, E>(this Task<Try<S, R, E>> tried, Action<S> doOnsubjectWhenOnError)
            => (await tried).OnFail(doOnsubjectWhenOnError);

        public static async Task<Try<S, R, E>> OnSuccess<S, R, E>(this Task<Try<S, R, E>> tried, Action<S, R> actionOnSuccess)
            => (await tried).OnSuccess(actionOnSuccess);

        public static async Task<Try<S, R, E>> OnSuccess<S, R, E>(this Task<Try<S, R, E>> tried, Action<R> doOnResultWhenOnSuccess)
            => (await tried).OnSuccess(doOnResultWhenOnSuccess);

    }
}
