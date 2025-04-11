namespace FluentCoding
{

    public static partial class SwitchMapExtension
    {
        public static async Task<IOptional<T>> BindAsync<O, T>(this Task<IOptional<O>> optional, Func<O, IOptional<T>> bindOnSome)
            => (await optional).Bind(bindOnSome);

        public static async Task<IOptional<O>> BindNoneAsync<O>(this Task<IOptional<O>> optional, Func<IOptional<O>> bindOnNone)
            => (await optional).BindNone(bindOnNone);

        public static async Task<IOptional<T>> BindAsync<O, T>(this Task<IOptional<O>> optional, Func<O, Task<IOptional<T>>> bindOnSome)
            => await (await optional).BindAsync(bindOnSome);

        public static async Task<IOptional<O>> BindNoneAsync<O>(this Task<IOptional<O>> optional, Func<Task<IOptional<O>>> bindOnNone)
            => await (await optional).BindNoneAsync(bindOnNone);
    }

}
