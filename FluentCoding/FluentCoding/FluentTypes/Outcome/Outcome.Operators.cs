namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>
    {
        public static implicit operator Outcome<F, S>(S success) => Success(success) as Outcome<F, S>;
        public static implicit operator Outcome<F, S>(F failure) => Failure(failure) as Outcome<F, S>;


        public static bool operator true(Outcome<F, S> value) => value.IsSuccess;
        public static bool operator false(Outcome<F, S> value) => value.IsFailure;
        public static bool operator !(Outcome<F, S> value) => value.IsFailure;
    }
}
