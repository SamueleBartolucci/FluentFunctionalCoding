namespace FluentFunctionalCoding
{
    internal sealed record Failure<TIn, TOut, TErr> : Try<TIn, TOut, TErr>
    {
        internal TIn _subject;
        internal TErr _errorResult;
        internal Exception _Error;



        internal Failure(TIn subject, TErr errorResult, Exception ex) : base() => (_subject, _errorResult, _Error) = (subject, errorResult, ex);


        public override bool IsSuccess => false;

        internal void Deconstruct(out TIn subject, out TErr result, out Exception ex) => (subject, result, ex) = (_subject, _errorResult, _Error);
    }
}
