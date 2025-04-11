namespace FluentCoding
{
    public record WhenIs<T> : IWhenIs<T>
    {
        internal readonly T _whenSubject;

        public static IWhenIs<T> When(T subject) => new WhenIs<T>(subject);

        private WhenIs(T subject) => this._whenSubject = subject;

        public IWhen<T> Is(bool isTrue) => When<T>.WhenMatch(_whenSubject, isTrue);
        public IWhen<T> Is(params Func<bool>[] predicates) => When<T>.WhenMatch(_whenSubject, predicates.All(predicate => predicate()));
        public IWhen<T> Is(params Func<T, bool>[] predicates) => When<T>.WhenMatch(_whenSubject, predicates.All(predidate => predidate(_whenSubject)));


        internal void Deconstruct(out T value) => (value) = (_whenSubject);

        //IWhenIs<T> IWhenIs<T>.Is(bool isTrue)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
