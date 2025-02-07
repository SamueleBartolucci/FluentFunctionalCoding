using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public M Match<M>(Func<S, M> onSuccess, Func<F, M> onFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => onSuccess(s),
            OutcomeFailure<F, S>(var f) => onFailure(f),
            _ => throw UnknowImplementation()
        };

        public M Match<M>(Func<S, M> onSuccess, M valueOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => onSuccess(s),
            OutcomeFailure<F, S>(_) => valueOnFailure,
            _ => throw UnknowImplementation()
        };
    }
}
