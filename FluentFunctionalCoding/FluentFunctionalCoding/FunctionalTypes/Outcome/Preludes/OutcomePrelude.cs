namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        public static Outcome<F, S> Outcome<F, S>(S success) => FluentFunctionalCoding.Outcome<F, S>.Right(success);
        public static Outcome<F, S> OutcomeFailure<F, S>(F failure) => FluentFunctionalCoding.Outcome<F, S>.Left(failure);

        public static Outcome<F, S> Outcome<F, S>(S value, Func<bool> isFailureWhen, F failureValue)
            => isFailureWhen() ? FluentFunctionalCoding.Outcome<F, S>.Left(failureValue) : FluentFunctionalCoding.Outcome<F, S>.Right(value);
        public static Outcome<F, S> Outcome<F, S>(S value, Func<S, bool> isFailureWhen, F failureValue) 
            => isFailureWhen(value) ? FluentFunctionalCoding.Outcome<F, S>.Left(failureValue) : FluentFunctionalCoding.Outcome<F, S>.Right(value);
    }
}
