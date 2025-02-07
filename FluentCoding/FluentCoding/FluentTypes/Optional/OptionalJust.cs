using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public record OptionalJust<O> : Optional<O>
    {
        internal O _value;
        internal OptionalJust(O Value) => _value = Value;

        internal void Deconstruct(out O value) => (value) = (_value);
    }
}
