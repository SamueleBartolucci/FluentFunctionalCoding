namespace FluentCoding
{
    public readonly struct WhenIs<T>
    {
        internal readonly T _subject;

        public static WhenIs<T> When(T subject) => new(subject);

        private WhenIs(T subject) => this._subject = subject;

        public When<T> Is(bool isTrue) => When<T>.WhenMatch(_subject, isTrue);
        public When<T> Is(params Func<bool>[] predicates) => When<T>.WhenMatch(_subject, predicates.All(p => p()));
        public When<T> Is(params Func<T, bool>[] predicates)
        {
            var sbj = _subject;
            return When<T>.WhenMatch(_subject, predicates.All(p => p(sbj)));
        }
    }
}
