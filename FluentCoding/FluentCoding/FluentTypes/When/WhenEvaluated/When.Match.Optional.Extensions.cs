namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static Optional<T1> Match<T, T1>(this When<Optional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.Map(when ? mapOnTrue : mapOnFalse);

        public static Optional<T> MatchTrue<T>(this When<Optional<T>> when, Func<T, T> mapOnTrue)
        => when ? when._subject.Map(mapOnTrue) : when._subject;

        public static Optional<T> MatchFalse<T>(this When<Optional<T>> when, Func<T, T> mapOnFalse)
             => !when ? when._subject.Map(mapOnFalse) : when._subject;
    }
}
