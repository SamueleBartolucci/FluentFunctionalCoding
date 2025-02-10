namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Outcome<F, S>> Is<F,S>(this WhenIs<Outcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs._subject switch 
            {
                OutcomeSuccess<F, S>(var s) => When<Outcome<F, S>>.WhenMatch(s.ToOutcome<F,S>(), predicates.All(p => p(s))),
                OutcomeFailure<F, S> n => When<Outcome<F, S>>.WhenMatch(n, false),
                _ => throw Outcome<F,S>.UnknownOutcomeType()
            };

    }
}
