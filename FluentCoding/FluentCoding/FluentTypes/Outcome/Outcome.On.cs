using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> On<X, Y>(Func<S, X> doOnSuccess, Func<F, Y> doOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(doOnSuccess),
            OutcomeFailure<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess<X>(Func<S, X> funcAsDoOnSuccess) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(funcAsDoOnSuccess),
            OutcomeFailure<F, S> o => o,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnFailure<Y>(Func<F, Y> funcAsDoOnFailure) => this switch
        {
            OutcomeSuccess<F, S> s => s,
            OutcomeFailure<F, S>(var f) => f.Do(funcAsDoOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };



        public Outcome<F, S> On(Action<S> doOnSuccess, Action<F> doOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(doOnSuccess),
            OutcomeFailure<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> OnSuccess(Action<S> doOnSuccess) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(_ => doOnSuccess(s)),
            OutcomeFailure<F, S> o => o,
            _ => throw UnknownOutcomeType()
        };


        public Outcome<F, S> OnFailure(Action<F> doOnFailure) => this switch
        {
            OutcomeSuccess<F, S> s => s,
            OutcomeFailure<F, S>(var f) => f.Do(doOnFailure).Map(Failure),
            _ => throw UnknownOutcomeType()
        };

    }
}
