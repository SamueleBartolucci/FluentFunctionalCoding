using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>
    {
        public Outcome<F, S> Do(params Action<S>[] actionsToApplyOnSuccessSubject) => this switch
        {
            OutcomeSuccess<F, S>(var  s) => s.Do(actionsToApplyOnSuccessSubject).Map(Success),
            OutcomeFailure<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

        public Outcome<F, S> Do<T>(params Func<S, T>[] funcsAsactionsToApplyOnSuccessSubject) => this switch
        {
            OutcomeSuccess<F, S>(var s) => s.Do(funcsAsactionsToApplyOnSuccessSubject).Map(Success),
            OutcomeFailure<F, S> f => f,
            _ => throw UnknownOutcomeType()
        };

    }
}
