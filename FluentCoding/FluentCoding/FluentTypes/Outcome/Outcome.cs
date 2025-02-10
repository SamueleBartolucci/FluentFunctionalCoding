using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{

    public abstract partial record Outcome<F, S>()
    {
        internal static NotImplementedException UnknownOutcomeType() => new NotImplementedException($"Unknown type, expected: {nameof(OutcomeSuccess<F, S>)} or {nameof(OutcomeFailure<F, S>)}");

        internal static Outcome<F, S> Success(S successValue) => new OutcomeSuccess<F, S>(successValue);

        internal static Outcome<F, S> Failure(F failureValue) => new OutcomeFailure<F, S>(failureValue);


        /// <summary>
        /// Check if is a success outcome
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess => this switch
        {
            OutcomeSuccess<F, S> => true,
            OutcomeFailure<F, S> => false,
            _ => throw UnknownOutcomeType()
        };


        /// <summary>
        /// Check if is a failure outcome
        /// </summary>
        /// <returns></returns>
        public bool IsFailure => this switch
        {
            OutcomeSuccess<F, S> => true,
            OutcomeFailure<F, S> => false,
            _ => throw UnknownOutcomeType()
        };
    }
}
