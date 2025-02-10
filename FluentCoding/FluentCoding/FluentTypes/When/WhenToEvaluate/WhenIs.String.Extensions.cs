namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<string> IsNullOrEmpty(this WhenIs<string> whenIs)
            => When<string>.WhenMatch(whenIs._subject, string.IsNullOrEmpty(whenIs._subject));

        public static When<string> IsNotNullOrEmpty(this WhenIs<string> whenIs)
            => When<string>.WhenMatch(whenIs._subject, !string.IsNullOrEmpty(whenIs._subject));

        public static When<string> IsEqualsTo(this WhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => When<string>.WhenMatch(whenIs._subject, whenIs._subject?.Equals(compare, options) ?? false);

    }
}
