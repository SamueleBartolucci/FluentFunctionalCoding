using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S1> Bind<F1, S1>(Func<S, Outcome<F,S1>> bindOnSuccess) => this switch
        {
            OutcomeSuccess<F, S>(var s) => bindOnSuccess(s),
            OutcomeFailure<F, S>(var f) => Outcome<F, S1>.Failure(f),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F1, S> BindFailure<F1, S1>(Func<F, Outcome<F1, S>> bindOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => Outcome<F1, S>.Success(s),
            OutcomeFailure<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F1, S1> BindFull<F1, S1>(Func<S, Outcome<F1, S1>> bindOnSuccess, Func<F, Outcome<F1, S1>> bindOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => bindOnSuccess(s),
            OutcomeFailure<F, S>(var f) => bindOnFailure(f),
            _ => throw UnknownOutcomeType()
        };
    }
}
