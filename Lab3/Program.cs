
using System;
using DateTime = Lab1.DateTime;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalendar grigorian = new GrigorianCalendar();
            ICalendar julian = new JulianCalendar();
            
            TestCalendar(grigorian);
            TestCalendar(julian);
        }

        private static void TestCalendar(ICalendar calendar)
        {
            DateTime testDate = new DateTime(17, 2, 2021);
            var isDayWeekend = calendar.IsDayWeekend(testDate);
            var isLeapYear = calendar.IsLeapYear(testDate);
            var nameFromDate = calendar.GetDayNameFromDate(testDate);
            var daysFromMonth = calendar.GetDaysFromMonthDate(testDate);
            Console.WriteLine($"\nCalendarType: {calendar.GetCalendarType()}\n");
            Console.WriteLine($"Your date - {testDate}\n\n nameFromDate: {nameFromDate}\n daysFromMonth: {daysFromMonth}\n isDayWeekend: {isDayWeekend}\n isLeapYear: {isLeapYear}\n");

        }
    }
}