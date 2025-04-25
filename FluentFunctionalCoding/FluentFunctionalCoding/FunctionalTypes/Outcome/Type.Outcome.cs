namespace FluentFunctionalCoding
{

    public abstract partial record Outcome<F, S>//  : Outcome<F, S>    
    {
        internal static NotImplementedException UnknownOutcomeType() => new NotImplementedException($"Unknown type, expected: {nameof(Right<F, S>)} or {nameof(Left<F, S>)}");
               

        /// <summary>
        /// Check if is a success outcome
        /// </summary>
        /// <returns></returns>
        public abstract bool IsSuccess { get; }


        /// <summary>
        /// Check if is a failure outcome
        /// </summary>
        /// <returns></returns>
        public bool IsFailure => !IsSuccess;
    }
}
