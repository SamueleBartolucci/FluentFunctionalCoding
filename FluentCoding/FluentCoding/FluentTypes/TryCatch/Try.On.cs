namespace FluentFunctionalCoding
{
    public abstract partial record Try<S, R, E>
    {
        public Try<S, R, E> OnFail(Action<S, E> actionOnError)
        {
            if (this is Failure<S, R, E>(var s, var e, _))
                actionOnError(s, e);

            return this;
        }

        public Try<S, R, E> OnFail(Action<S> doOnsubjectWhenOnError)
        {
            if (this is Failure<S, R, E>(var s, _, _))
                doOnsubjectWhenOnError(s);

            return this;
        }


        public Try<S, R, E> OnSuccess(Action<S, R> actionOnSuccess)
        {
            if (this is Success<S, R, E>(var s, var r))
                actionOnSuccess(s, r);

            return this;
        }

        public Try<S, R, E> OnSuccess(Action<R> doOnResultWhenOnSuccess)
        {
            if (this is Success<S, R, E>(_, var r))
                doOnResultWhenOnSuccess(r);

            return this;
        }

    }
}
