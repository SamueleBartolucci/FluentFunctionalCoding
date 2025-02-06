
namespace FluentCoding
{
    public static partial class TryExtension
    {

        public static async Task<R> MatchFailAsync<S,R,E>(this Task<Try<S,R,E>> tried, Func<E, R> onError)
             => (await tried).MatchFail(onError);

        public static async Task<R> MatchFailAsync<S, R, E>(this Task<Try<S, R, E>> tried, R valueOnFail)
            => (await tried).MatchFail(valueOnFail);

        public static async Task<M> MatchFailAsync<S, R, E, M>(this Task<Try<S, R, E>> tried, Func<R, M> onSuccess, Func<E, M> onError)
            => (await tried).Match(onSuccess, onError);
    }
}
