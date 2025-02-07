using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public record OutcomeSuccess<F, S> : Outcome<F, S>
    {
        internal S _successValue;
        internal OutcomeSuccess(S SuccessValue) => (_successValue) = (SuccessValue);

        internal void Deconstruct(out S value) => (value) = (_successValue);
    }
}
