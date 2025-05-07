using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{DateTime}"/> to perform conditional checks and comparisons on dates.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Compares two dates and returns an integer that indicates their relative values.
        /// </summary>
        /// <param name="inputDate">The first date to compare.</param>
        /// <param name="compareDate">The second date to compare.</param>
        /// <param name="dateOnly">If true, compares only the date part; otherwise, compares the full DateTime.</param>
        /// <returns>An integer that indicates the relative values of the dates: less than zero if inputDate is earlier, zero if equal, greater than zero if later.</returns>
        private static int CompareDates(DateTime inputDate, DateTime compareDate, bool dateOnly)
            => (dateOnly ? inputDate.Date.CompareTo(compareDate.Date) : inputDate.CompareTo(compareDate));
        
        /// <summary>
        /// Checks the comparison result using the provided check function and equality allowance.
        /// </summary>
        /// <param name="comparisonResult">The result of the date comparison.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <param name="check">A function to check the comparison result.</param>
        /// <returns>True if the check passes or equality is allowed and the result is zero.</returns>
        private static bool CheckResult(int comparisonResult, bool allowEquals, Func<int, bool> check)
            => check(comparisonResult) || (allowEquals && comparisonResult == 0);

        private static bool IsLess(int comparisonResult) => comparisonResult < 0;
        private static bool IsMore(int comparisonResult) => comparisonResult > 0;

        /// <summary>
        /// Determines whether the subject date is greater than the specified date.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{DateTime}"/> instance.</param>
        /// <param name="compareDate">The date to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <param name="dateOnly">If true, compares only the date part; otherwise, compares the full DateTime.</param>
        /// <returns>A <see cref="When{DateTime}"/> indicating if the subject is greater than (or equal to, if allowed) the compare date.</returns>
        public static When<DateTime> IsGraterThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
             => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(r => CheckResult(r, allowEquals, IsMore))); 

        /// <summary>
        /// Determines whether the subject date is less than the specified date.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{DateTime}"/> instance.</param>
        /// <param name="compareDate">The date to compare with the subject.</param>
        /// <param name="allowEquals">Whether to allow equality as a valid result.</param>
        /// <param name="dateOnly">If true, compares only the date part; otherwise, compares the full DateTime.</param>
        /// <returns>A <see cref="When{DateTime}"/> indicating if the subject is less than (or equal to, if allowed) the compare date.</returns>
        public static When<DateTime> IsLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
            => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(r => CheckResult(r, allowEquals, IsLess)));

        /// <summary>
        /// Determines whether the subject date is equal to the specified date.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{DateTime}"/> instance.</param>
        /// <param name="compareDate">The date to compare with the subject.</param>
        /// <param name="dateOnly">If true, compares only the date part; otherwise, compares the full DateTime.</param>
        /// <returns>A <see cref="When{DateTime}"/> indicating if the subject is equal to the compare date.</returns>
        public static When<DateTime> IsEqualsTo<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool dateOnly = false)
            => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly) == 0);
    }
}
