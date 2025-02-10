namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<bool> IsTrue(this WhenIs<bool> whenIs)
            => When<bool>.WhenMatch(whenIs._subject, whenIs._subject);

        public static When<bool> IsFalse(this WhenIs<bool> whenIs)
            => When<bool>.WhenMatch(whenIs._subject, !whenIs._subject);

    }
}
