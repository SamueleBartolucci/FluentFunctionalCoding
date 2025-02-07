using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        [Pure]
        public Outcome<F, O> ToEither<F>(Func<F> onNone) => this switch
        {
                OptionalJust<O> (var x) => Outcome<F, O>.Success(x),
                _ => Outcome<F, O>.Failure(onNone()),
        };

        [Pure]
        public Outcome<F, O> ToEither<F>(F valueOnNone) => this switch
        {
            OptionalJust<O>(var x) => Outcome<F, O>.Success(x),
            _ => Outcome<F, O>.Failure(valueOnNone),
        };
    }
}
