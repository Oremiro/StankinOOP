using Lab1;
using Lab3;

namespace Lab5
{
    public class ExtendedGrigorianCalendar: GrigorianCalendar
    {
        
        public override bool IsDayWeekend(DateTime dateTime)
        {
            var days = CalendarJsonParser.GetHolidayDayFromJson();
            return days.Contains(dateTime);
        }
    }
}