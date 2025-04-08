namespace FluentCoding
{
    public abstract partial record Try<S, R, E>
    {
        public R MatchFail(Func<E, R> onError)
             => this switch
             {
                 Success<S, R, E>(_, var r) => r,
                 Failure<S, R, E>(_, var e, _) => onError(e),
                 _ => throw UnknowImplementation()
             };

        public R MatchFail(R valueOnFail)
             => this switch
             {
                 Success<S, R, E>(_, var r) => r,
                 Failure<S, R, E>(var s, _, _) => valueOnFail,
                 _ => throw UnknowImplementation()
             };

        public M Match<M>(Func<R, M> onSuccess, Func<E, M> onError)
           => this switch
           {
               Success<S, R, E>(_, var r) => onSuccess(r),
               Failure<S, R, E>(_, var e, _) => onError(e),
               _ => throw UnknowImplementation()
           };
    }
}
