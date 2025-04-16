namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<Outcome<F, S>> Is<F, S>(this IWhenIs<Outcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<Right<F, S>>(Right<F, S> (var s)) => When<Outcome<F, S>>.WhenMatch(s.ToOutcome<F, S>(), predicates.All(p => p(s))),
                WhenIs<Left<F, S>>(Left<F, S> n) => When<Outcome<F, S>>.WhenMatch(n, false),
                _ => throw Outcome<F, S>.UnknownOutcomeType()
            };

    }
}
