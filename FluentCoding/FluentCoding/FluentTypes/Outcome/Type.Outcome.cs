namespace FluentCoding
{

    public abstract partial record Outcome<F, S>() : IOutcome<F, S>    
    {
        internal static NotImplementedException UnknownOutcomeType() => new NotImplementedException($"Unknown type, expected: {nameof(Right<F, S>)} or {nameof(Left<F, S>)}");

        internal static IOutcome<F, S> Success(S successValue) => new Right<F, S>(successValue);

        internal static IOutcome<F, S> Failure(F failureValue) => new Left<F, S>(failureValue);


        /// <summary>
        /// Check if is a success outcome
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess => this switch
        {
            Right<F, S> => true,
            Left<F, S> => false,
            _ => throw UnknownOutcomeType()
        };


        /// <summary>
        /// Check if is a failure outcome
        /// </summary>
        /// <returns></returns>
        public bool IsFailure => !IsSuccess;
    }
}
