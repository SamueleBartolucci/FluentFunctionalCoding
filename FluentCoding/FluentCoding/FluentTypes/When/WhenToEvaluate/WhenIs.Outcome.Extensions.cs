namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<Outcome<F, S>> Is<F, S>(this WhenIs<Outcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs._whenSubject switch
            {
                Right<F, S>(var s) => When<Outcome<F, S>>.WhenMatch(s.ToOutcome<F, S>(), predicates.All(p => p(s))),
                Left<F, S> n => When<Outcome<F, S>>.WhenMatch(n, false),
                _ => throw Outcome<F, S>.UnknownOutcomeType()
            };

    }
}
