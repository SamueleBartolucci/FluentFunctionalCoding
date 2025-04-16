namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        public static IWhenIs<T> When<T>(this T whenSubject) => WhenIs<T>.When(whenSubject);
    }
}
