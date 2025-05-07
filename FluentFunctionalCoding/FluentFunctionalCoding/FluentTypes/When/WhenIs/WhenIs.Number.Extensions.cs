using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{decimal}"/>, <see cref="WhenIs{int}"/>, and <see cref="WhenIs{long}"/> to perform numeric comparisons.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether the subject is greater than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{decimal}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{decimal}"/> indicating if the subject is greater than (or equal to, if allowed) the value.</returns>
        public static When<decimal> IsGreaterThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => whenIs._ToWhen(sbj => sbj > value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is less than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{decimal}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{decimal}"/> indicating if the subject is less than (or equal to, if allowed) the value.</returns>
        public static When<decimal> IsLessThan(this WhenIs<decimal> whenIs, decimal value, bool allowEquals = false)
            => whenIs._ToWhen(sbj => sbj < value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is equal to the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{decimal}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <returns>A <see cref="When{decimal}"/> indicating if the subject is equal to the value.</returns>
        public static When<decimal> IsEqualsTo(this WhenIs<decimal> whenIs, decimal value)
            => whenIs._ToWhen(sbj => sbj == value);

        /// <summary>
        /// Determines whether the subject is greater than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{int}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{int}"/> indicating if the subject is greater than (or equal to, if allowed) the value.</returns>
        public static When<int> IsGreaterThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
          => whenIs._ToWhen(sbj => sbj  > value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is less than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{int}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{int}"/> indicating if the subject is less than (or equal to, if allowed) the value.</returns>
        public static When<int> IsLessThan(this WhenIs<int> whenIs, int value, bool allowEquals = false)
            => whenIs._ToWhen(sbj => sbj  < value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is equal to the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{int}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <returns>A <see cref="When{int}"/> indicating if the subject is equal to the value.</returns>
        public static When<int> IsEqualsTo(this WhenIs<int> whenIs, int value)
            => whenIs._ToWhen(sbj => sbj  == value);

        /// <summary>
        /// Determines whether the subject is greater than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{long}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{long}"/> indicating if the subject is greater than (or equal to, if allowed) the value.</returns>
        public static When<long> IsGreaterThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
          => whenIs._ToWhen(sbj => sbj  > value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is less than the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{long}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <returns>A <see cref="When{long}"/> indicating if the subject is less than (or equal to, if allowed) the value.</returns>
        public static When<long> IsLessThan(this WhenIs<long> whenIs, long value, bool allowEquals = false)
            => whenIs._ToWhen(sbj => sbj  < value || (allowEquals && sbj == value));

        /// <summary>
        /// Determines whether the subject is equal to the specified value.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{long}"/> instance.</param>
        /// <param name="value">The value to compare with the subject.</param>
        /// <returns>A <see cref="When{long}"/> indicating if the subject is equal to the value.</returns>
        public static When<long> IsEqualsTo(this WhenIs<long> whenIs, long value)
            => whenIs._ToWhen(sbj => sbj  == value);
    }
}
