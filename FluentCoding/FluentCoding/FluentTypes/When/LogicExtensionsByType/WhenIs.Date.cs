using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenIsExtension
    {
        private static int CompareDates(DateTime inputDate, DateTime compareDate, bool dateOnly)
            => dateOnly ? inputDate.Date.CompareTo(compareDate.Date) : inputDate.CompareTo(compareDate);

        public static When<DateTime> WhenGraterThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false) 
        {
            var result = CompareDates(whenIs._subject, compareDate, dateOnly);
            return new When<DateTime>(whenIs._subject, result > 0 || (allowEquals && result == 0));
        }

        public static When<DateTime> WhenLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool allowEquals = false, bool dateOnly = false)
        {
            var result = CompareDates(whenIs._subject, compareDate, dateOnly);
            return new When<DateTime>(whenIs._subject, result < 0 || (allowEquals && result == 0));
        }

        public static When<DateTime> WhenLessThan<T>(this WhenIs<DateTime> whenIs, DateTime compareDate, bool dateOnly = false)
        {
            var result = CompareDates(whenIs._subject, compareDate, dateOnly);
            return new When<DateTime>(whenIs._subject, result == 0);
        }


    }
}
