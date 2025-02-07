using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Optional<S> ToOptional() => this switch
        {
            OutcomeSuccess<F, S> (var s) => Optional<S>.Some(s),
            _ => Optional<S>.None()
        };

        public Optional<F> ToOptionalFailue() => this switch
        {
            OutcomeFailure<F, S>(var f) => Optional<F>.Some(f),
            _ => Optional<F>.None(),
        };
    }
}
