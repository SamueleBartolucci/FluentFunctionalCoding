namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        private static int CompareDates(DateTime inputDate, DateTime compareDate, bool dateOnly)
            => dateOnly ? inputDate.Date.CompareTo(compareDate.Date) : inputDate.CompareTo(compareDate);

        public static When<DateTime> IsGraterThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
        {
            var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
            return When<DateTime>.WhenMatch(whenIs._whenSubject, result > 0 || (allowEquals && result == 0));
        }

        public static When<DateTime> IsLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
        {
            var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
            return When<DateTime>.WhenMatch(whenIs._whenSubject, result < 0 || (allowEquals && result == 0));
        }

        public static When<DateTime> IsLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool dateOnly = false)
        {
            var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
            return When<DateTime>.WhenMatch(whenIs._whenSubject, result == 0);
        }


    }
}
