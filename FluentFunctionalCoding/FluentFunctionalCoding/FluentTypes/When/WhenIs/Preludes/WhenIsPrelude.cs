namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        public static WhenIs<T> When<T>(T subject) => new WhenIs<T>(subject);
        public static async Task<WhenIs<T>> When<T>(Task<T> whenSubject) => Prelude.When(await whenSubject);
    }
}


