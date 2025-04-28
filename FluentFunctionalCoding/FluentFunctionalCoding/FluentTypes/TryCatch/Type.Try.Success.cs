namespace FluentFunctionalCoding
{
    internal sealed record Success<TIn, TOut, TErr> : Try<TIn, TOut, TErr>
    {
        internal TIn _subject;
        internal TOut _result;



        internal Success(TIn subject, TOut result) : base() => (_subject, _result) = (subject, result);

        public override bool IsSuccess => true;

        internal void Deconstruct(out TIn subject, out TOut result) => (subject, result) = (_subject, _result);
    }
}
