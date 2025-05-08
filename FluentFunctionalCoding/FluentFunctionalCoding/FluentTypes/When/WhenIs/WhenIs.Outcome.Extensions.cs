using FluentFunctionalCoding.FluentPreludes;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Checks the outcome subject using the provided predicates on the success value.
        /// If the subject is a Right, applies all predicates to the success value; if all return true, returns a When with true, otherwise false.
        /// If the subject is a Left, returns a When with false.
        /// </summary>
        /// <typeparam name="F">The failure type of the Outcome.</typeparam>
        /// <typeparam name="S">The success type of the Outcome.</typeparam>
        /// <param name="whenIs">The WhenIs instance wrapping the Outcome.</param>
        /// <param name="predicates">Predicates to apply to the success value.</param>
        /// <returns>A When instance indicating if all predicates matched on the success value.</returns>
        public static When<Outcome<F, S>> Is<F, S>(this WhenIs<Outcome<F, S>> whenIs, params Func<S, bool>[] predicates)
            => whenIs switch
            {
                WhenIs<Right<F, S>>(Right<F, S> (var s)) => Prelude._WhenMatch(s.ToOutcome<F, S>(), predicates.All(p => p(s))),
                WhenIs<Left<F, S>>(Left<F, S> n) => Prelude._WhenMatch(n as Outcome<F, S>, false),
                _ => throw Outcome<F, S>.UnknownOutcomeType()
            };

    }
}
