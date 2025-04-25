namespace FluentFunctionalCoding
{
    public abstract partial record Try<S, R, E>
    {
        internal static Exception CarryException(S subject, Exception e) => e;        

        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(Success<S, R, E>)} or {nameof(Failure<S, R, E>)}");
        
        public abstract bool IsSuccess { get; }

        public bool IsFail => !IsSuccess;

        internal Try() { }

    }
}


