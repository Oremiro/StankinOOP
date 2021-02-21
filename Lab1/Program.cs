using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalendar calendar = new Calendar();

            DateTime testDate = new DateTime(17, 2, 2021);

            var isDayWeekend = calendar.IsDayWeekend(testDate);
            var isLeapYear = calendar.IsLeapYear(testDate);
            var nameFromDate = calendar.GetDayNameFromDate(testDate);
            var daysFromMonth = calendar.GetDaysFromMonthDate(testDate);
            
            Console.WriteLine($"Your date - {testDate}\n\n nameFromDate: {nameFromDate}\n daysFromMonth: {daysFromMonth}\n isDayWeekend: {isDayWeekend}\n isLeapYear: {isLeapYear}");
        }
    }
}