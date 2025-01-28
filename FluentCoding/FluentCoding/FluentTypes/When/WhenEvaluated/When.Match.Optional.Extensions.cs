namespace FluentCoding
{
    public static partial class WhenExtension
    {
        public static Optional<T1> Match<T, T1>(this When<Optional<T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.Map(when ? mapOnTrue : mapOnFalse);


        public static Optional<T> MatchTrue<T>(this When<Optional<T>> when, Func<T, T> mapOnTrue)
        {
            if (when)
                return when._subject.Map(mapOnTrue);

            return when._subject;
        }

        public static Optional<T> MatchFalse<T>(this When<Optional<T>> when, Func<T, T> mapOnFalse)
        {
            if (!when)
                return when._subject.Map(mapOnFalse);

            return when._subject;
        }
    }
}
