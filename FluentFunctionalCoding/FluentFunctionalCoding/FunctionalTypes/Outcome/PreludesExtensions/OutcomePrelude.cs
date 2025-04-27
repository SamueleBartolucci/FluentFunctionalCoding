namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        public static Outcome<F, S> ToOutcome<F, S>(this S success) => Prelude.Outcome<F, S>(success);
        public static Outcome<F, S> ToOutcomeFailure<F, S>(this F failure) => Prelude.OutcomeFailure<F, S>(failure);

        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<bool> isFailureWhen, F failureValue) => Prelude.Outcome(value, isFailureWhen, failureValue);
        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<S, bool> isFailureWhen, F failureValue) => Prelude.Outcome(value, isFailureWhen, failureValue);
    }
}
