using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        public static When<bool> IsTrue(this WhenIs<bool> whenIs) =>  whenIs._ToWhen(sbj=>sbj);
        
        public static When<bool> IsFalse(this WhenIs<bool> whenIs) => whenIs._ToWhen(sbj => !sbj);
    }
}
