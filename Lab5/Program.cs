using System;
using Calendar = Lab3.Calendar;
using DateTime = Lab1.DateTime;
using ICalendar = Lab3.ICalendar;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new ExtendedGrigorianCalendar();
            var date = new DateTime(27, 3, 2021);
            var weekend = calendar.IsDayWeekend(date);
            Console.WriteLine(calendar.GetWorkCalendarFormatString(date));
        }
    }
}