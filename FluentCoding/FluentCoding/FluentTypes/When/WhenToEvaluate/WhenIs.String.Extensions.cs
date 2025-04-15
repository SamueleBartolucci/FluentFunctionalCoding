namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        public static IWhen<string> IsNullOrEmpty(this IWhenIs<string> whenIs)
            => whenIs.ToWhen(string.IsNullOrEmpty);

        public static IWhen<string> IsNotNullOrEmpty(this IWhenIs<string> whenIs)
            => whenIs.ToWhen(sbj => !string.IsNullOrEmpty(sbj));

        public static IWhen<string> IsEqualsTo(this IWhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => whenIs.ToWhen(sbj => sbj?.Equals(compare, options) ?? false);

    }
}
