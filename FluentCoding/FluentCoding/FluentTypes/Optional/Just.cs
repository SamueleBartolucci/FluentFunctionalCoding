using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public record Just<A> : Optional<A>
    {
        internal A _value;
        internal Just(A Value) => _value = Value;

        internal void Deconstruct(out A value) => (value) = (_value);
    }
}
