using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {
        [Pure]
        public Outcome<F, O> ToOutcome<F>(Func<F> onNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Right(x),
            _ => Outcome<F, O>.Left(onNone()),
        };

        [Pure]
        public Outcome<F, O> ToOutcome<F>(F valueOnNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Right(x),
            _ => Outcome<F, O>.Left(valueOnNone),
        };
    }
}
