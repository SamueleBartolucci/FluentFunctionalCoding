namespace FluentFunctionalCoding
{

    public static partial class SwitchMapExtension
    {
        public static async Task<Optional<T>> BindAsync<O, T>(this Task<Optional<O>> optional, Func<O, Optional<T>> bindOnSome)
            => (await optional).Bind(bindOnSome);

        public static async Task<Optional<O>> BindNoneAsync<O>(this Task<Optional<O>> optional, Func<Optional<O>> bindOnNone)
            => (await optional).BindNone(bindOnNone);

        public static async Task<Optional<T>> BindAsync<O, T>(this Task<Optional<O>> optional, Func<O, Task<Optional<T>>> bindOnSome)
            => await (await optional).BindAsync(bindOnSome);

        public static async Task<Optional<O>> BindNoneAsync<O>(this Task<Optional<O>> optional, Func<Task<Optional<O>>> bindOnNone)
            => await (await optional).BindNoneAsync(bindOnNone);
    }

}
