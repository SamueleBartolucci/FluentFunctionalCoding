namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        public TOut MatchFail(Func<TErr, TOut> onError)
             => this switch
             {
                 Success<TIn, TOut, TErr>(_, var r) => r,
                 Failure<TIn, TOut, TErr>(_, var e, _) => onError(e),
                 _ => throw UnknowImplementation()
             };

        public TOut MatchFail(TOut valueOnFail)
             => this switch
             {
                 Success<TIn, TOut, TErr>(_, var r) => r,
                 Failure<TIn, TOut, TErr>(var s, _, _) => valueOnFail,
                 _ => throw UnknowImplementation()
             };

        public M Match<M>(Func<TOut, M> onSuccess, Func<TErr, M> onError)
           => this switch
           {
               Success<TIn, TOut, TErr>(_, var r) => onSuccess(r),
               Failure<TIn, TOut, TErr>(_, var e, _) => onError(e),
               _ => throw UnknowImplementation()
           };
    }
}
