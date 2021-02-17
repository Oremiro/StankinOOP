namespace Lab1
{
    public interface ICalendar
    {
        public string GetDayNameFromDate(DateTime dateTime);
        public bool IsDayWeekend(DateTime dateTime);
        public int GetDaysFromMonthDate(DateTime dateTime);
        public bool IsLeapYear(DateTime dateTime);
    }
}