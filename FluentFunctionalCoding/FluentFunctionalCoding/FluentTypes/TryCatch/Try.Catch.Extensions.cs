namespace FluentFunctionalCoding
{
    public static partial class TryExtension
    {
        public static Try<Tin, TOut, E2> Catch<Tin, TOut, E2>(this Try<Tin, TOut, Exception> tried, Func<Tin, Exception, E2> functOnCatch)
            => tried switch
            {
                Success<Tin, TOut, Exception>(var s, var r) => new Success<Tin, TOut, E2>(s, r),
                Failure<Tin, TOut, Exception>(var s, var r, var ex) => new Failure<Tin, TOut, E2>(s, functOnCatch(s, ex), ex),
                _ => throw Try<Tin, TOut, E2>.UnknowImplementation()
            };
    }
}
