using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<bool> IsTrue(this IWhenIs<bool> whenIs) =>  whenIs.ToWhen(sbj=>sbj);
        
        public static IWhen<bool> IsFalse(this IWhenIs<bool> whenIs) => whenIs.ToWhen(sbj => !sbj);
    }
}
