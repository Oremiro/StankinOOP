using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class Calendar : ICalendar
    {
        private static readonly string[] DayNames =
        {
            "SAT",
            "SUN",
            "MON",
            "TUE",
            "WED",
            "THU",
            "FRI",
        };

        private static readonly Dictionary<int, List<int>> MonthCodes = new Dictionary<int, List<int>>()
        {
            [0] = new()
            {
                Month.April, Month.July
            },
            [1] = new()
            {
                Month.January, Month.October
            },
            [2] = new()
            {
                Month.May
            },
            [3] = new()
            {
                Month.August
            },
            [4] = new()
            {
                Month.February, Month.March, Month.November
            },
            [5] = new()
            {
                Month.June
            },
            [6] = new()
            {
                Month.September, Month.December
            }
        };

        private static readonly List<DateTime> Holidays = new List<DateTime>
        {
            new DateTime(31, 12, 0000),
            new DateTime(1, 9, 0000),
            new DateTime(23, 2, 0000),
            new DateTime(8, 3, 0000),
            new DateTime(7, 1, 0000),
        };
        
        public string GetDayNameFromDate(DateTime dateTime)
        {
            var dayCode = CalculateDayCode(dateTime);
            var day = DayNames[dayCode];
            return day;
        }

        private int CalculateYearCode(DateTime dateTime)
        {
            var year = dateTime.Year;
            var last2Digits = year % 100;
            var code = (6 + last2Digits + last2Digits / 4) % 7;
            return code;
        }

        private int CalculateMonthCode(DateTime dateTime)
        {
            var monthCode = MonthCodes.FirstOrDefault(q => q.Value.Contains(dateTime.Month)).Key;
            return monthCode;
        }

        private int CalculateDayCode(DateTime dateTime)
        {
            var additional = 0;
            if (IsLeapYear(dateTime))
            {
                additional = 1;
            }
            var monthCode = CalculateMonthCode(dateTime);
            var yearCode = CalculateYearCode(dateTime);
            var day = dateTime.Day;
            var dayValue = (day + additional + monthCode + yearCode) % 7;
            return dayValue;
        }
        
        /// <summary>
        /// https://docs.microsoft.com/ru-ru/office/troubleshoot/excel/determine-a-leap-year
        /// </summary>
        /// <param name="dateTime"></param>
        public bool IsLeapYear(DateTime dateTime)
        {
        
            var year = dateTime.Year;
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool IsDayWeekend(DateTime dateTime)
        {
            var day = GetDayNameFromDate(dateTime);
            if (day == "SAT" || day == "SUN")
            {
                return true;
            }

            foreach (var holiday in Holidays)
            {
                if (holiday.Day == dateTime.Day && holiday.Month == dateTime.Month)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetDaysFromMonthDate(DateTime dateTime)
        {
            var month = dateTime.Month;
            if (month % 2 == 1)
            {
                return 31;
            }

            if (month == 2)
            {
                if (IsLeapYear(dateTime))
                {
                    return 29;
                }

                return 28;
            }

            return 30;
        }
    }
}