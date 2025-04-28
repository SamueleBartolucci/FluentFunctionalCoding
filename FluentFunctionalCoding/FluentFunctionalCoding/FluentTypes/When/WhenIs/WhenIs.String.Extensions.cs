namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        public static When<string> IsNullOrEmpty(this WhenIs<string> whenIs)
            => whenIs._ToWhen(string.IsNullOrEmpty);

        public static When<string> IsNotNullOrEmpty(this WhenIs<string> whenIs)
            => whenIs._ToWhen(sbj => !string.IsNullOrEmpty(sbj));

        public static When<string> IsEqualsTo(this WhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => whenIs._ToWhen(sbj => sbj?.Equals(compare, options) ?? false);

    }
}
