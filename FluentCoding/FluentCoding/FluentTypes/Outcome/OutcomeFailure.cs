using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public record OutcomeFailure<F, S> : Outcome<F, S>
    {
        internal F _failureValue;
        internal OutcomeFailure(F SuccessValue) => (_failureValue) = (SuccessValue);

        internal void Deconstruct(out F value) => (value) = (_failureValue);
    }
}
