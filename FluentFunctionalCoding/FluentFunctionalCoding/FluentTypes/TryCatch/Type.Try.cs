namespace FluentFunctionalCoding
{
    public abstract partial record Try<TIn, TOut, TErr>
    {
        internal static Exception CarryException(TIn subject, Exception e) => e;        

        internal static NotImplementedException UnknowImplementation() => new NotImplementedException($"Unknown type, expected: {nameof(Success<TIn, TOut, TErr>)} or {nameof(Failure<TIn, TOut, TErr>)}");

        public virtual bool IsSuccess => this switch
        {
            Success<TIn, TOut, TErr> success => true,
            _ => false
        };

        public bool IsFail => !IsSuccess;

        internal Try() { }

    }
}


