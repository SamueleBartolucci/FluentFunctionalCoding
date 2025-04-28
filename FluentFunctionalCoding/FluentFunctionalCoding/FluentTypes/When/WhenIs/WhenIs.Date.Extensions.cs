using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        private static int CompareDates(DateTime inputDate, DateTime compareDate, bool dateOnly)
            => (dateOnly ? inputDate.Date.CompareTo(compareDate.Date) : inputDate.CompareTo(compareDate));
        
        private static bool CheckResult(int comparisonResult, bool allowEquals, Func<int, bool> check)
            => check(comparisonResult) || (allowEquals && comparisonResult == 0);

        private static bool IsLess(int comparisonResult) => comparisonResult < 0;
        private static bool IsMore(int comparisonResult) => comparisonResult > 0;

        public static When<DateTime> IsGraterThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
             => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(r => CheckResult(r, allowEquals, IsMore))); 

        public static When<DateTime> IsLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
            => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(r => CheckResult(r, allowEquals, IsLess)));

        public static When<DateTime> IsEqualsTo<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool dateOnly = false)
            => whenIs._ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly) == 0);
    }
}
