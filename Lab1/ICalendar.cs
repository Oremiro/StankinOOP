namespace Lab1
{
    public interface ICalendar
    {
        string GetDayNameFromDate(DateTime dateTime);
        bool IsDayWeekend(DateTime dateTime);
        int GetDaysFromMonthDate(DateTime dateTime);
        bool IsLeapYear(DateTime dateTime);
    }
}