using System;

namespace Lab1
{
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
}