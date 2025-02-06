using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public record TrySuccess<S, R, E> : Try<S, R, E>
    {
        internal S _subject;
        internal R _result;



        internal TrySuccess(S subject, R result) : base() => (_subject, _result) = (subject, result);     

        internal void Deconstruct(out S subject, out R result) => (subject, result) = (_subject, _result);
    }
}
