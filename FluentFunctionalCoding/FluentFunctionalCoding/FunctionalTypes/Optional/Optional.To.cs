using System.Diagnostics.Contracts;

namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Converts the Optional to an Outcome, using the provided function to generate the failure value if None.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <param name="onNone">Function to generate the failure value.</param>
        /// <returns>An Outcome representing success or failure.</returns>
        [Pure]
        public Outcome<F, O> ToOutcome<F>(Func<F> onNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Right(x),
            _ => Outcome<F, O>.Left(onNone()),
        };

        /// <summary>
        /// Converts the Optional to an Outcome, using the provided value as the failure value if None.
        /// </summary>
        /// <typeparam name="F">The failure type.</typeparam>
        /// <param name="valueOnNone">The failure value to use if None.</param>
        /// <returns>An Outcome representing success or failure.</returns>
        [Pure]
        public Outcome<F, O> ToOutcome<F>(F valueOnNone) => this switch
        {
            Some<O>(var x) => Outcome<F, O>.Right(x),
            _ => Outcome<F, O>.Left(valueOnNone),
        };
    }
}
