using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> On(Func<S, S> funcAsDoOnSuccess, Func<F, F> funcAsDoOnFailure) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(_ => funcAsDoOnSuccess(s)),
            OutcomeFailure<F, S>(var f) => this.Do(_ => funcAsDoOnFailure(f)),
            _ => throw UnknowImplementation()
        };

        public Outcome<F, S> OnSuccess(Action<S> doOnSuccess) => this switch
        {
            OutcomeSuccess<F, S>(var s) => this.Do(_ => doOnSuccess(s)),
            OutcomeFailure<F, S> o => o,
            _ => throw UnknowImplementation()
        };


        public Outcome<F, S> OnFailure(Action<S> doOnSuccess, Action<F> doOnFailure) => this switch
        {
            OutcomeSuccess<F, S> s => s,
            OutcomeFailure<F, S>(var f) => this.Do(_ => doOnFailure(f)),
            _ => throw UnknowImplementation()
        };

    }
}
