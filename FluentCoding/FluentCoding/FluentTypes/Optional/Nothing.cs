using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public record Nothing<A> : Optional<A>
    {
    }
}
