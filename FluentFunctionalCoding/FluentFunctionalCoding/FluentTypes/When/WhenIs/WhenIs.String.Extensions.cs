namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{string}"/> to perform conditional checks on strings.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether the subject string is null or empty.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{string}"/> instance.</param>
        /// <returns>A <see cref="When{string}"/> indicating if the string is null or empty.</returns>
        public static When<string> IsNullOrEmpty(this WhenIs<string> whenIs)
            => whenIs._ToWhen(string.IsNullOrEmpty);

        /// <summary>
        /// Determines whether the subject string is not null or empty.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{string}"/> instance.</param>
        /// <returns>A <see cref="When{string}"/> indicating if the string is not null or empty.</returns>
        public static When<string> IsNotNullOrEmpty(this WhenIs<string> whenIs)
            => whenIs._ToWhen(sbj => !string.IsNullOrEmpty(sbj));

        /// <summary>
        /// Determines whether the subject string is equal to the specified string, using the given comparison options.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{string}"/> instance.</param>
        /// <param name="compare">The string to compare with the subject.</param>
        /// <param name="options">String comparison options (default: InvariantCultureIgnoreCase).</param>
        /// <returns>A <see cref="When{string}"/> indicating if the strings are equal.</returns>
        public static When<string> IsEqualsTo(this WhenIs<string> whenIs, string compare, StringComparison options = StringComparison.InvariantCultureIgnoreCase)
            => whenIs._ToWhen(sbj => sbj?.Equals(compare, options) ?? false);

    }
}
