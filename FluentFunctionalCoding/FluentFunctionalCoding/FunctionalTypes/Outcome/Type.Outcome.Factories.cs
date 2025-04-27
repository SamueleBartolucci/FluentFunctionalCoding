namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>//  : Outcome<F, S>    
    {
        public static Outcome<F, S> Right(S successValue) => new Right<F, S>(successValue);

        public static Outcome<F, S> Left(F failureValue) => new Left<F, S>(failureValue);

    }
}
