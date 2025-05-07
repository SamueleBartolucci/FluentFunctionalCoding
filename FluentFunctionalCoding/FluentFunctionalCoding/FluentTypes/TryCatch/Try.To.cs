using FluentFunctionalCoding.FluentPreludes;
using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        /// <summary>
        /// Converts the Try to an Optional, returning Some if successful, otherwise None.
        /// </summary>
        public Optional<TOut> ToOptional() => this switch
        {
            Success<TIn, TOut, TErr>(var _, var r) => Optional<TOut>.Some(r),
            Failure<TIn, TOut, TErr> _ => Optional<TOut>.None(),
            _ => throw UnknowImplementation()
        };

        /// <summary>
        /// Converts the Try to an Outcome (Either), returning Right if successful, otherwise Left with the error.
        /// </summary>
        [Pure]
        public Outcome<TErr, TOut> ToEither() => this switch
        {
            Success<TIn, TOut, TErr>(_, var r) => Outcome<TErr, TOut>.Right(r),
            Failure<TIn, TOut, TErr>(_, var e, _) => Outcome<TErr, TOut>.Left(e),
            _ => throw UnknowImplementation()
        };

        /// <summary>
        /// Converts the Try to an Outcome (Either) using Exception as the error type.
        /// </summary>
        [Pure]
        public Outcome<Exception, TOut> ToEitherUsingException() => this switch
        {
            Success<TIn, TOut, TErr>(_, var r) => Outcome<Exception, TOut>.Right(r),
            Failure<TIn, TOut, TErr>(_, _, var ex) => Outcome<Exception, TOut>.Left(ex),
            _ => throw UnknowImplementation()
        };
    }
}

