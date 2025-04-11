namespace FluentCoding
{
    public partial record When<T> : IWhen<T>
    {

        public T1 Match<T1>(Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => (_isTrue ? mapOnTrue : mapOnFalse)(_subject);

        public T MatchTrue(Func<T, T> mapOnTrue)
            => _isTrue ? mapOnTrue(_subject) : _subject;

        public T MatchFalse(Func<T, T> mapOnFalse)
            => _isTrue ? _subject : mapOnFalse(_subject);
    }
}
