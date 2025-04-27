namespace FluentFunctionalCoding
{
    public static partial class WhenExtension
    {
        public static Optional<T1> Match<T, T1>(this When<Optional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.Map(when.IsTrue ? mapOnTrue : mapOnFalse);

        public static Optional<T> MatchTrue<T>(this When<Optional<T>> when, Func<T, T> mapOnTrue)
        => when.IsTrue ? when._subject.Map(mapOnTrue) : when._subject;

        public static Optional<T> MatchFalse<T>(this When<Optional<T>> when, Func<T, T> mapOnFalse)
             => !when.IsTrue ? when._subject.Map(mapOnFalse) : when._subject;
    }
}
