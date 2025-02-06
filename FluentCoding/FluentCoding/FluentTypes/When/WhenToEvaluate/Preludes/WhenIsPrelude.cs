namespace FluentCoding
{
    public static partial class Prelude
    {
        public static WhenIs<T> When<T>(this T whenSubject) => WhenIs<T>.When(whenSubject);
    }
}
