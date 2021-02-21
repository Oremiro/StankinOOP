namespace Lab1
{
    public static class DateTimeValidator
    {
        public static bool ValidateDay(int day)
        {
            return day <= 31 && day >= 1;
        }

        public static bool ValidateMonth(int month)
        {
            return month <= 12 && month >= 1;
        }

        public static bool ValidateYear(int year)
        {
            return year >= 0;
        }
    }
}