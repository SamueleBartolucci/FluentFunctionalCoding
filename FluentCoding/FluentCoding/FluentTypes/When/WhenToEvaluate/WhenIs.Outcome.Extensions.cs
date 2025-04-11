namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<IOutcome<F, S>> Is<F, S>(this IWhenIs<IOutcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<Right<F, S>>(Right<F, S> (var s)) => When<IOutcome<F, S>>.WhenMatch(s.ToOutcome<F, S>(), predicates.All(p => p(s))),
                WhenIs<Left<F, S>>(Left<F, S> n) => When<IOutcome<F, S>>.WhenMatch(n, false),
                _ => throw Outcome<F, S>.UnknownOutcomeType()
            };

    }
}
