using Lab1;

namespace Lab3
{
    public class GrigorianCalendar: Calendar
    {

        public GrigorianCalendar() : base()
        {
            CalendarType = new CalendarType(CalendarTypes.GrigorianCalendar);
        }
        
        public override bool IsLeapYear(DateTime dateTime)
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

    }
}