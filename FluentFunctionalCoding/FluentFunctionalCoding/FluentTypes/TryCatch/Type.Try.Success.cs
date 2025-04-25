namespace FluentFunctionalCoding
{
    public record Success<S, R, E> : Try<S, R, E>
    {
        internal S _subject;
        internal R _result;



        internal Success(S subject, R result) : base() => (_subject, _result) = (subject, result);

        public override bool IsSuccess => true;

        internal void Deconstruct(out S subject, out R result) => (subject, result) = (_subject, _result);
    }
}
