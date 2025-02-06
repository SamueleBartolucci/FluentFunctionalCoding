
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => SwitchMap<T, T1>.Switch(subject, defaultCase);

        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, T1 defaultCase) => SwitchMap<T, T1>.Switch(subject, defaultCase);
    }

}
