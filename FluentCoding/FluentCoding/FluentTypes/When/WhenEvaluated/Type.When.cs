namespace FluentCoding
{
    public partial record When<T> : IWhen<T>
    {
        internal readonly T _subject;
        internal readonly bool _isTrue = false;

        internal static IWhen<T> WhenMatch(T whenSubject, bool isTrue) => new When<T>(whenSubject, isTrue);

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
