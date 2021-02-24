using Lab1;

namespace Lab3
{
    public interface ICalendar
    {
        WeekDay GetDayNameFromDate(DateTime dateTime);
        bool IsDayWeekend(DateTime dateTime);
        int GetDaysFromMonthDate(DateTime dateTime);
        bool IsLeapYear(DateTime dateTime);
        CalendarType GetCalendarType();
    }
}