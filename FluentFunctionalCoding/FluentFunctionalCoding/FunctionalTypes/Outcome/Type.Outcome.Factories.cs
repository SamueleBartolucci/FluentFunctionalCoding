namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>//  : Outcome<F, S>    
    {
        public static Outcome<F, S> Success(S successValue) => new Right<F, S>(successValue);

        public static Outcome<F, S> Failure(F failureValue) => new Left<F, S>(failureValue);

    }
}
