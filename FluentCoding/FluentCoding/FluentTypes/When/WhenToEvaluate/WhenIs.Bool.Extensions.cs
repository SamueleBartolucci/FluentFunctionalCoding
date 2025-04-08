namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<bool> IsTrue(this WhenIs<bool> whenIs)
            => When<bool>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject);

        public static When<bool> IsFalse(this WhenIs<bool> whenIs)
            => When<bool>.WhenMatch(whenIs._whenSubject, !whenIs._whenSubject);

    }
}
