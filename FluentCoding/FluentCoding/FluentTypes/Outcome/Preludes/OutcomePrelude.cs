namespace FluentCoding
{
    public static partial class Prelude
    {
        public static Outcome<F, S> ToOutcome<F, S>(this S success) => Outcome<F, S>.Success(success);
        public static Outcome<F, S> ToOutcomeFailure<F, S>(this F failure) => Outcome<F, S>.Failure(failure);

        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<bool> isFailureWhen, F failureValue) => isFailureWhen() ? Outcome<F, S>.Failure(failureValue) : Outcome<F, S>.Success(value);
        public static Outcome<F, S> ToOutcome<F, S>(this S value, Func<S, bool> isFailureWhen, F failureValue) => isFailureWhen(value) ? Outcome<F, S>.Failure(failureValue) : Outcome<F, S>.Success(value);
    }
}
