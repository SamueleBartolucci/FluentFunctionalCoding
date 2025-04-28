namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        public static Task<WhenIs<T>> WhenAsync<T>(this Task<T> whenSubject) => Prelude.When(whenSubject);
    }
}
