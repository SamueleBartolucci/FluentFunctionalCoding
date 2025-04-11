using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O> : IOptional<O>
    {
        [Pure]
        public IOutcome<F, O> ToOutcome<F>(Func<F> onNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Success(x),
            _ => Outcome<F, O>.Failure(onNone()),
        };

        [Pure]
        public IOutcome<F, O> ToOutcome<F>(F valueOnNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Success(x),
            _ => Outcome<F, O>.Failure(valueOnNone),
        };
    }
}
