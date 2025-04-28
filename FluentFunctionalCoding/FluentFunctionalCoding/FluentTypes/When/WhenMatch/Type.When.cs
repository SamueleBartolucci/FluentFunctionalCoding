namespace FluentFunctionalCoding
{
    public partial record When<T>
    {
        internal readonly T _subject;
        internal readonly bool _isTrue = false;

        

        public bool IsTrue => _isTrue;
        public bool IsFalse => !_isTrue;

        internal When(T switchSubject, bool isTrue)
        {
            this._subject = switchSubject;
            this._isTrue = isTrue;
        }

        internal void Deconstruct(out T value) => (value) = (_subject);
    }
}
