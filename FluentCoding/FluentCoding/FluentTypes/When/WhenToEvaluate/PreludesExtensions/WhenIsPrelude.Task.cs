namespace FluentCoding
{
    public static partial class Prelude
    {
        public static async Task<IWhenIs<T>> WhenAsync<T>(this Task<T> whenSubject)
        {
            await whenSubject;
            return WhenIs<T>.When(whenSubject.Result);
        }
    }
}
