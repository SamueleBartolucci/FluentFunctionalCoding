namespace FluentCoding
{
    public record WhenIs<T>
    {
        internal readonly T _whenSubject;

        public static WhenIs<T> When(T subject) => new(subject);

        private WhenIs(T subject) => this._whenSubject = subject;

        public When<T> Is(bool isTrue) => When<T>.WhenMatch(_whenSubject, isTrue);
        public When<T> Is(params Func<bool>[] predicates) => When<T>.WhenMatch(_whenSubject, predicates.All(predicate => predicate()));
        public When<T> Is(params Func<T, bool>[] predicates) => When<T>.WhenMatch(_whenSubject, predicates.All(predidate => predidate(_whenSubject)));
    }
}
