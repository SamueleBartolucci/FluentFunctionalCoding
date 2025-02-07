using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public abstract partial record Try<S, R, E>
    {
        public Optional<R> ToOptional() => this switch
        {
            TrySuccess<S, R, E> (var s, var r) => r.Some(),
            TryFailure<S, R, E> (var s, var e, var ex) => Optional<R>.None(),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<E, R> ToEither<F>() => this switch
        {
            TrySuccess<S,R,E>(_ ,var r) => Outcome<E, R>.Success(r),
            TryFailure<S,R,E>(_, var e, _) => Outcome<E, R>.Failure(e),
            _ => throw UnknowImplementation()
        };

        [Pure]
        public Outcome<Exception, R> ToEitherUsingException<F>() => this switch
        {
            TrySuccess<S, R, E>(_, var r) => Outcome<Exception, R>.Success(r),
            TryFailure<S, R, E>(_, _, var ex) => Outcome<Exception, R>.Failure(ex),
            _ => throw UnknowImplementation()
        };
    }
}

