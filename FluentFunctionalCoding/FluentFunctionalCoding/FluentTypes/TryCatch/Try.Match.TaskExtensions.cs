
namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {

        public static async Task<TOut> MatchFailAsync<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, Func<TErr, TOut> onError)
             => (await tried).MatchFail(onError);

        public static async Task<TOut> MatchFailAsync<TIn, TOut, TErr>(this Task<Try<TIn, TOut, TErr>> tried, TOut valueOnFail)
            => (await tried).MatchFail(valueOnFail);

        public static async Task<M> MatchAsync<TIn, TOut, TErr, M>(this Task<Try<TIn, TOut, TErr>> tried, Func<TOut, M> onSuccess, Func<TErr, M> onError)
            => (await tried).Match(onSuccess, onError);
    }
}
