namespace FluentFunctionalCoding
{
    public partial record When<T>
    {

        public T1 Match<T1>(Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => (IsTrue ? mapOnTrue : mapOnFalse)(_subject);

        public T MatchTrue(Func<T, T> mapOnTrue)
            => IsTrue ? mapOnTrue(_subject) : _subject;

        public T MatchFalse(Func<T, T> mapOnFalse)
            => IsTrue ? _subject : mapOnFalse(_subject);
    }
}
