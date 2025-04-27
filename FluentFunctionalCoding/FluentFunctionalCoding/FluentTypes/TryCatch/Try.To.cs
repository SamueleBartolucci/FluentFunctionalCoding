using FluentFunctionalCoding.FluentPreludes;
using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Try<S, R, E>
    {
        public Optional<R> ToOptional() => this switch
        {
            Success<S, R, E>(var _, var r) => Prelude.Optional(r),
            Failure<S, R, E> _ => Prelude.OptionalNone<R>(),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<E, R> ToEither<F>() => this switch
        {
            Success<S, R, E>(_, var r) => Prelude.Outcome<E, R>(r),
            Failure<S, R, E>(_, var e, _) => Prelude.OutcomeFailure<E, R>(e),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<Exception, R> ToEitherUsingException<F>() => this switch
        {
            Success<S, R, E>(_, var r) => Prelude.Outcome<Exception, R>(r),
            Failure<S, R, E>(_, _, var ex) => Prelude.OutcomeFailure<Exception, R>(ex),
            _ => throw UnknowImplementation()
        };
    }
}

