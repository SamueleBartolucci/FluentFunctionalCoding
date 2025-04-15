using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    public static partial class WhenIsExtension
    {
        private static int CompareDates(DateTime inputDate, DateTime compareDate, bool dateOnly)
            => dateOnly ? inputDate.Date.CompareTo(compareDate.Date) : inputDate.CompareTo(compareDate);

        public static IWhen<DateTime> IsGraterThan<T>(this IWhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
             => whenIs.ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(result => result > 0 || (allowEquals && result == 0)));
        //{
        //    var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
            
        //    return When<DateTime>.WhenMatch(whenIs._whenSubject, result > 0 || (allowEquals && result == 0));
        //}

        public static IWhen<DateTime> IsLessThan<T>(this IWhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
            => whenIs.ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly).Map(result => result < 0 || (allowEquals && result == 0)));
        //{

        //    var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
        //    return When<DateTime>.WhenMatch(whenIs._whenSubject, result < 0 || (allowEquals && result == 0));
        //}

        public static IWhen<DateTime> IsLessThan<T>(this IWhenIs<DateTime> whenIs, DateTime compareDate, bool dateOnly = false)
            => whenIs.ToWhen(sbj => CompareDates(sbj, compareDate, dateOnly) == 0);
        //{
        //    var result = CompareDates(whenIs._whenSubject, compareDate, dateOnly);
        //    return When<DateTime>.WhenMatch(whenIs._whenSubject, result == 0);
        //}


    }
}
