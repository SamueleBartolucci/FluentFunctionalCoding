using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F1, S1> Map<F1, S1>(Func<S, S1> mapOnSuccess, Func<F, F1> mapOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => Outcome<F1, S1>.Success(mapOnSuccess(s)),
            OutcomeFailure<F, S>(var f) => Outcome<F1, S1>.Failure(mapOnFailure(f)),
            _ => throw UnknowImplementation()
        };


        public Outcome<F, S1> MapSuccess<S1>(Func<S, S1> mapOnSuccess) => this switch
        {
            OutcomeSuccess<F, S>(var s) => Outcome<F, S1>.Success(mapOnSuccess(s)),
            OutcomeFailure<F, S>(var f) => Outcome<F, S1>.Failure(f),
            _ => throw UnknowImplementation()
        };


        public Outcome<F1, S> MapFailure<F1, S>(Func<F, F1> mapOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => Outcome<F1, S>.Success(s),
            OutcomeFailure<F, S>(var f) => Outcome<F1, S>.Failure(mapOnFailure(f)),
            _ => throw UnknowImplementation()
        };
    }
}
