namespace FluentCoding
{
    public record Failure<S, R, E> : Try<S, R, E>
    {
        internal S _subject;
        internal E _result;
        internal Exception _Error;



        internal Failure(S subject, E result, Exception ex) : base() => (_subject, _result, _Error) = (subject, result, ex);

        internal void Deconstruct(out S subject, out E result, out Exception ex) => (subject, result, ex) = (_subject, _result, _Error);
    }
}
