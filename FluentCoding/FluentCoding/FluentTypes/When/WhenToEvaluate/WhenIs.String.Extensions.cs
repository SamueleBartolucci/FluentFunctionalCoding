namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        public static When<string> IsNullOrEmpty(this WhenIs<string> whenIs)
            => When<string>.WhenMatch(whenIs._whenSubject, string.IsNullOrEmpty(whenIs._whenSubject));

        public static When<string> IsNotNullOrEmpty(this WhenIs<string> whenIs)
            => When<string>.WhenMatch(whenIs._whenSubject, !string.IsNullOrEmpty(whenIs._whenSubject));

        public static When<string> IsEqualsTo(this WhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => When<string>.WhenMatch(whenIs._whenSubject, whenIs._whenSubject?.Equals(compare, options) ?? false);

    }
}
