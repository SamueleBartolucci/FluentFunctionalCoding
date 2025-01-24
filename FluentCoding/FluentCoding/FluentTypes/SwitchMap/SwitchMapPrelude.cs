
namespace FluentCoding
{
    public static class SwitchMapPrelude
    {        
        internal static SwitchMap<T, T1> SwitchMap<T, T1>(this T subject, Func<T, T1> defaultCase) => new SwitchMap<T, T1>(subject, defaultCase);
    }

}
