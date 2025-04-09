
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static SwitchMapBase<T, T1> Switch<T, T1>(this T subject) => SwitchMapBase<T, T1>.Switch(subject);

        public static ISwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => SwitchMap<T, T1>.Switch(subject, defaultCase);

        public static ISwitchMap<T, T1> Switch<T, T1>(this T subject, T1 defaultResult) => SwitchMap<T, T1>.Switch(subject, defaultResult);
    }

}
