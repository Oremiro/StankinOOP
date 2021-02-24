using Lab1;
using Lab3;

namespace Lab5
{
    public class ExtendedGrigorianCalendar: GrigorianCalendar
    {
        
        public override bool IsDayWeekend(DateTime dateTime)
        {
            return base.IsDayWeekend(dateTime);
        }
    }
}