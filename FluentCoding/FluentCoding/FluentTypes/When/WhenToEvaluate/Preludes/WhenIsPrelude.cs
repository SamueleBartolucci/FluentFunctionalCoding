namespace FluentCoding
{
    public static partial class Prelude
    {
        public static WhenIs<T> When<T>(this T whenSubject) => WhenIs<T>.When(whenSubject);
        //public static WhenIs<T> When<T>(this T whenSubject, params Func<T, bool>[] andPredicatesOnSubject) => new When<T> (whenSubject, andPredicatesOnSubject);

    }
}
