using FluentFunctionalCoding.FluentPreludes;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Outcome<F, S>> Is<F, S>(this WhenIs<Outcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<Right<F, S>>(Right<F, S> (var s)) => Prelude._WhenMatch(s.ToOutcome<F, S>(), predicates.All(p => p(s))),
                WhenIs<Left<F, S>>(Left<F, S> n) => Prelude._WhenMatch(n as Outcome<F, S>, false),
                _ => throw Outcome<F, S>.UnknownOutcomeType()
            };

    }
}
