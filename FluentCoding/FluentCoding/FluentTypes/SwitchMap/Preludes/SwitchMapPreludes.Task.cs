
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static SwitchMap<Task<T>, T1> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase) => new SwitchMap<Task<T>, T1>(subject, sbj => defaultCase(sbj.Result));
    }

}
