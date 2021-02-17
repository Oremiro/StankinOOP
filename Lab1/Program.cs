using System;

namespace Lab1
{
    interface IDateTime
    {
        
    }

    class DateTime: IDateTime
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


    static class DateTimeValidator
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
    interface ICalendar
    {
        public string GetDayNameFromDate(DateTime dateTime);
        public bool IsDayWeekend(DateTime dateTime);
        public int GetDaysFromMonthDate(DateTime dateTime);
    }
    class Calendar: ICalendar
    {
        public string GetDayNameFromDate(DateTime dateTime)
        {
            throw new NotImplementedException();
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