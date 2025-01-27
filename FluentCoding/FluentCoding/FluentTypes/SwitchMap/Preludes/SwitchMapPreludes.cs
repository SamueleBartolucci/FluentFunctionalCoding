
namespace FluentCoding
{
    public static partial class Prelude
    {
        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => new SwitchMap<T, T1>(subject, defaultCase);        
    }

}
