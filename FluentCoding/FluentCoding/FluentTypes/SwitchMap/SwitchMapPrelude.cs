
namespace FluentCoding
{
    public static class Prelude
    {
        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => new SwitchMap<T, T1>(subject, defaultCase);
        public static SwitchMap<Task<T>, T1> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase) => new SwitchMap<Task<T>, T1>(subject, sbj => defaultCase(sbj.Result));
    }

}
