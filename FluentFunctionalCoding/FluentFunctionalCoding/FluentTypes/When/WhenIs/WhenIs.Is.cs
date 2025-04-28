namespace FluentFunctionalCoding
{
    public partial record WhenIs<T>
    {       
        public When<T> Is(bool isTrue) => Prelude._WhenMatch(_whenSubject, isTrue);
        public When<T> Is(params Func<bool>[] predicates) => Prelude._WhenMatch(_whenSubject, predicates.All(predicate => predicate()));
        public When<T> Is(params Func<T, bool>[] predicates) => Prelude._WhenMatch(_whenSubject, predicates.All(predidate => predidate(_whenSubject)));
    }
}
