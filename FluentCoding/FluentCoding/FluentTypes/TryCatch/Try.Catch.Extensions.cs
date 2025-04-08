namespace FluentCoding
{
    public static partial class TryExtension
    {
        public static Try<S, R, E2> Catch<S, R, E2>(this Try<S, R, Exception> tried, Func<S, Exception, E2> functOnCatch)
            => tried switch
            {
                Success<S, R, Exception>(var s, var r) => new Success<S, R, E2>(s, r),
                Failure<S, R, Exception>(var s, var r, var ex) => new Failure<S, R, E2>(s, functOnCatch(s, ex), ex),
                _ => throw Try<S, R, E2>.UnknowImplementation()
            };
    }
}
