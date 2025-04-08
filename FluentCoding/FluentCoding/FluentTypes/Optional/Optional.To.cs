using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        [Pure]
        public Outcome<F, O> ToOutcome<F>(Func<F> onNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Success(x),
            _ => Outcome<F, O>.Failure(onNone()),
        };

        [Pure]
        public Outcome<F, O> ToOutcome<F>(F valueOnNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Success(x),
            _ => Outcome<F, O>.Failure(valueOnNone),
        };
    }
}
