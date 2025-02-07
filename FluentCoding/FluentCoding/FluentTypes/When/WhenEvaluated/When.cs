namespace FluentCoding
{
    public readonly partial struct When<T>
    {
        internal readonly T _subject;
        internal readonly bool _isTrue = false;

        internal static When<T> WhenMatch(T whenSubject, bool isTrue) => new(whenSubject, isTrue);

        public bool IsTrue => _isTrue;
        public bool IsFalse => !_isTrue;

        private When(T switchSubject, bool isTrue)
        {
            this._subject = switchSubject;
            this._isTrue = isTrue;
        }

        internal void Deconstruct(out T value) => (value) = (_subject);
    }
}
