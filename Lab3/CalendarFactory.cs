namespace Lab3
{
    public class CalendarFactory
    {
        public ICalendar CreateGrigorianCalendar() =>
            new GrigorianCalendar();

        public ICalendar CreateJulianCalendar() =>
            new JulianCalendar();
    }
}