namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        public static WhenIs<T> When<T>(this T whenSubject) => Prelude.When(whenSubject);
    }
}
