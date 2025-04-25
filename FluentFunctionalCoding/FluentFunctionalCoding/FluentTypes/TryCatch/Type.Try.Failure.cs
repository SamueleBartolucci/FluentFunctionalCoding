namespace FluentFunctionalCoding
{
    public record Failure<S, R, E> : Try<S, R, E>
    {
        internal S _subject;
        internal E _errorResult;
        internal Exception _Error;



        internal Failure(S subject, E errorResult, Exception ex) : base() => (_subject, _errorResult, _Error) = (subject, errorResult, ex);


        public override bool IsSuccess => false;

        internal void Deconstruct(out S subject, out E result, out Exception ex) => (subject, result, ex) = (_subject, _errorResult, _Error);
    }
}
