namespace FluentFunctionalCoding
{
    public static partial class WhenExtension
    {
        public static Outcome<F, T1> Match<F, T, T1>(this When<Outcome<F, T>> when, Func<T, T1> mapOnTrue, Func<T, T1> mapOnFalse)
            => when._subject.MapSuccess(when.IsTrue ? mapOnTrue : mapOnFalse);


        public static Outcome<F, T> MatchTrue<F, T>(this When<Outcome<F, T>> when, Func<T, T> mapOnTrue)
            => when.IsTrue ? when._subject.MapSuccess(mapOnTrue) : when._subject;

        public static Outcome<F, T> MatchFalse<F, T>(this When<Outcome<F, T>> when, Func<T, T> mapOnFalse)
            => !when.IsTrue ? when._subject.MapSuccess(mapOnFalse) : when._subject;

    }
}
