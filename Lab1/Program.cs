using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public interface IDateTime
    {
    }

    public class DateTime : IDateTime
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public DateTime(int day, int month, int year)
        {
            if (DateTimeValidator.ValidateDay(day) == false ||
                DateTimeValidator.ValidateMonth(month) == false ||
                DateTimeValidator.ValidateYear(year) == false)
            {
                throw new ArgumentOutOfRangeException($"Invalid arguments inside {this.GetType()} object;");
            }

            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day}.{Month}.{Year}";
        }
    }


    public static class DateTimeValidator
    {
        public static bool ValidateDay(int day)
        {
            return day <= 31 && day >= 1;
        }

        public static bool ValidateMonth(int month)
        {
            return month <= 12 && month >= 1;
        }

        public static bool ValidateYear(int year)
        {
            return year > 0;
        }
    }

    public interface ICalendar
    {
        public string GetDayNameFromDate(DateTime dateTime);
        public bool IsDayWeekend(DateTime dateTime);
        public int GetDaysFromMonthDate(DateTime dateTime);
    }

    public enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
        
    }
    public class Month
    {
        public const int January = 1;
        public const int February = 2;
        public const int March = 3;
        public const int April = 4;
        public const int May = 5;
        public const int June = 6;
        public const int July = 7;
        public const int August = 8;
        public const int September = 9;
        public const int October = 10;
        public const int November = 11;
        public const int December = 12;
    }

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
            var monthCode = CalculateMonthCode(dateTime);
            var yearCode = CalculateYearCode(dateTime);
            var day = dateTime.Day;
            var dayValue = (day + monthCode + yearCode) % 7;
            return dayValue;
        }
        
        public bool IsDayWeekend(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public int GetDaysFromMonthDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}