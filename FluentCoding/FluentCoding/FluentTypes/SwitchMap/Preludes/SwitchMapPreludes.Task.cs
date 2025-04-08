
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static async Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase)
        {
            await (subject);
            return SwitchMap<T, T1>.Switch(subject.Result, defaultCase);
        }

        public static async Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, T1 defaultCase)
        {
            await (subject);
            return SwitchMap<T, T1>.Switch(subject.Result, defaultCase);
        }
    }

}
