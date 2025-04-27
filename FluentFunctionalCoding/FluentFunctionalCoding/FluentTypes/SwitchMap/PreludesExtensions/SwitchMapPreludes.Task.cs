
namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        public static Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase)
         => Prelude.Switch(subject, defaultCase);

        public static Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, T1 defaultCase)
            => Prelude.Switch(subject, defaultCase);
    }

}
