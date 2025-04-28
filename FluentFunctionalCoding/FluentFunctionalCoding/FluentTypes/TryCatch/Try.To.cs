using FluentFunctionalCoding.FluentPreludes;
using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        public Optional<TOut> ToOptional() => this switch
        {
            Success<TIn, TOut, TErr>(var _, var r) => Optional<TOut>.Some(r),
            Failure<TIn, TOut, TErr> _ => Optional<TOut>.None(),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<TErr, TOut> ToEither() => this switch
        {
            Success<TIn, TOut, TErr>(_, var r) => Outcome<TErr, TOut>.Right(r),
            Failure<TIn, TOut, TErr>(_, var e, _) => Outcome<TErr, TOut>.Left(e),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<Exception, TOut> ToEitherUsingException() => this switch
        {
            Success<TIn, TOut, TErr>(_, var r) => Outcome<Exception, TOut>.Right(r),
            Failure<TIn, TOut, TErr>(_, _, var ex) => Outcome<Exception, TOut>.Left(ex),
            _ => throw UnknowImplementation()
        };
    }
}

