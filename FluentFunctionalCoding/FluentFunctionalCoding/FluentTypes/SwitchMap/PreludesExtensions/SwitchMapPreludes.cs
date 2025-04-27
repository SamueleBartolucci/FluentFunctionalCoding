
namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        public static SwitchMapBase<T, T1> Switch<T, T1>(this T subject) => Prelude.Switch<T, T1>(subject);

        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => Prelude.Switch(subject, defaultCase);

        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, T1 defaultResult) => Prelude.Switch(subject, defaultResult);
    }

}
