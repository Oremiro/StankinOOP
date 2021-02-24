using System.Collections.Generic;
using System.Linq;
using Lab1;

namespace Lab3
{
    public abstract class Calendar: ICalendar
    {
        protected CalendarType CalendarType { get; set; }

        private static readonly WeekDay[] DayNames =
        {
             new WeekDay(DaysNames.Saturday),
             new WeekDay(DaysNames.Sunday),
             new WeekDay(DaysNames.Monday),
             new WeekDay(DaysNames.Tuesday),
             new WeekDay(DaysNames.Wednesday),
             new WeekDay(DaysNames.Thursday),
             new WeekDay(DaysNames.Friday),
            
        };
        
        private static readonly Dictionary<int, List<int>> MonthCodes = new Dictionary<int, List<int>>()
        {
            [0] = new List<int>()
            {
                Month.April, Month.July
            },
            [1] = new List<int>()
            {
                Month.January, Month.October
            },
            [2] = new List<int>()
            {
                Month.May
            },
            [3] = new List<int>()
            {
                Month.August
            },
            [4] = new List<int>()
            {
                Month.February, Month.March, Month.November
            },
            [5] = new List<int>()
            {
                Month.June
            },
            [6] = new List<int>()
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
        
        public WeekDay GetDayNameFromDate(DateTime dateTime)
        {
            var dayCode = CalculateDayCode(dateTime);
            var day = DayNames[dayCode];
            return day;
        }

        public bool IsDayWeekend(DateTime dateTime)
        {
            var day = GetDayNameFromDate(dateTime);
            if (day.ToString() == DaysNames.Saturday || day.ToString() == DaysNames.Sunday)
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

        public CalendarType GetCalendarType()
        {
            return CalendarType;
        }
        
        public abstract bool IsLeapYear(DateTime dateTime);
        
    }
}