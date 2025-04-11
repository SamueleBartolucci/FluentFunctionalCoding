using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Try<S, R, E>
    {
        public IOptional<R> ToOptional() => this switch
        {
            Success<S, R, E>(var s, var r) => r.ToOptional(),
            Failure<S, R, E>(var s, var e, var ex) => Optional<R>.None(),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public IOutcome<E, R> ToEither<F>() => this switch
        {
            Success<S, R, E>(_, var r) => Outcome<E, R>.Success(r),
            Failure<S, R, E>(_, var e, _) => Outcome<E, R>.Failure(e),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public IOutcome<Exception, R> ToEitherUsingException<F>() => this switch
        {
            Success<S, R, E>(_, var r) => Outcome<Exception, R>.Success(r),
            Failure<S, R, E>(_, _, var ex) => Outcome<Exception, R>.Failure(ex),
            _ => throw UnknowImplementation()
        };
    }
}

