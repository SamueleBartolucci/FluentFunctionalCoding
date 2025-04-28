namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        public Try<TIn, TOut, TErr> OnFail(Action<TIn, TErr> actionOnError)
        {
            if (this is Failure<TIn, TOut, TErr>(var s, var e, _))
                actionOnError(s, e);

            return this;
        }

        public Try<TIn, TOut, TErr> OnFail(Action<TIn> doOnsubjectWhenOnError)
        {
            if (this is Failure<TIn, TOut, TErr>(var s, _, _))
                doOnsubjectWhenOnError(s);

            return this;
        }


        public Try<TIn, TOut, TErr> OnSuccess(Action<TIn, TOut> actionOnSuccess)
        {
            if (this is Success<TIn, TOut, TErr>(var s, var r))
                actionOnSuccess(s, r);

            return this;
        }

        public Try<TIn, TOut, TErr> OnSuccess(Action<TOut> doOnResultWhenOnSuccess)
        {
            if (this is Success<TIn, TOut, TErr>(_, var r))
                doOnResultWhenOnSuccess(r);

            return this;
        }

    }
}
