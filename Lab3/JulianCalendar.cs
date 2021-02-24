using Lab1;

namespace Lab3
{
    public class JulianCalendar: Calendar
    {
        public JulianCalendar() : base()
        {
            CalendarType = new CalendarType(CalendarTypes.JulianCalendar);
        }

        public override bool IsLeapYear(DateTime dateTime)
        {
            var year = dateTime.Year;
            
            if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }
    }
}