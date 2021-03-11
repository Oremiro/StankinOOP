using System.Collections.Generic;
using Lab1;
using Lab3;

namespace Lab5
{
    public class ExtendedGrigorianCalendar: GrigorianCalendar
    {
        private static readonly Dictionary<int, string> MonthNames = new Dictionary<int, string>()
        {
            [1] = "Jan",
            [2] = "Feb",
            [3] = "Mar",
            [4] = "Apr",
            [5] = "May",
            [6] = "Jun",
            [7] = "Jul",
            [8] = "Aug",
            [9] = "Sep",
            [10] = "Oct",
            [11] = "Nov",
            [12] = "Dec",
        };
        
        private static readonly Dictionary<string, int> DayNameWithIntCorrelation = new Dictionary<string, int>()
        {
            [DaysNames.Sunday] = 0,
            [DaysNames.Monday] = 1,
            [DaysNames.Tuesday] = 2,
            [DaysNames.Wednesday] = 3,
            [DaysNames.Thursday] = 4,
            [DaysNames.Friday] = 5,
            [DaysNames.Saturday] = 6,

        };

        private const int PADDING_VALUE = 3;
        public override bool IsDayWeekend(DateTime dateTime)
        {
            var days = CalendarJsonParser.GetHolidayDayFromJson();
            return days.Contains(dateTime.ToString());
        }

        public string GetWorkCalendarFormatString(DateTime dateTime)
        {
            var calendarString = "";
            var month = MonthNames[dateTime.Month];
            var calendarDaysCount = this.GetDaysFromMonthDate(dateTime);
            calendarString += GetTopLine(dateTime) + "\n";
            calendarString += GetDaysLine() + "\n";
            calendarString += GetCalendarBuiltString(dateTime);
            return calendarString;

        }

        private string GetDaysLine()
        {
            return $"{DaysNames.Sunday} {DaysNames.Monday} {DaysNames.Tuesday} {DaysNames.Wednesday} {DaysNames.Thursday} {DaysNames.Friday} {DaysNames.Saturday}";
        }

        private string GetYearMonth(DateTime dateTime)
        {
            return $"{dateTime.Year} - {MonthNames[dateTime.Month]}";
        }
        
        private string GetTopLine(DateTime dateTime)
        {
            var daysLength = GetDaysLine().Length;
            var yearMonth = GetYearMonth(dateTime);
            var padding = daysLength / 2 + 1 - yearMonth.Length / 2;
            return $"{"".PadLeft(padding)}{yearMonth}";
        }

        private string GetCalendarBuiltString(DateTime dateTime)
        {
            var resultString = "";
            WeekDay weekDay = GetDayNameFromDate(new DateTime(1, dateTime.Month, dateTime.Year));
            var startValue = DayNameWithIntCorrelation[weekDay.ToString()];
            var firstPaddingValue = startValue * PADDING_VALUE + 1;
            for(int day = 1; day <= GetDaysFromMonthDate(dateTime);)
            {
                for (int i = startValue; i < 7 && day <= GetDaysFromMonthDate(dateTime); i++)
                {
                    var dayString = $"{day}";
                    if (IsDayWeekend(new DateTime(day, dateTime.Month, dateTime.Year)))
                    {
                        dayString += "*";
                    }
                    resultString += $"{"".PadRight(firstPaddingValue)}{dayString.PadRight(PADDING_VALUE, ' ')} ";
                    firstPaddingValue = 0;
                    day++;
                }

                startValue = 0;
                resultString += "\n";
            }

            return resultString;
            
        }
        
    }
}