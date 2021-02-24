namespace Lab3
{
    public class WeekDay
    {
        private string Day { get; set; }

        public WeekDay(string dayName)
        {
            Day = dayName;
        }

        public override string ToString()
        {
            return Day;
        }
    }
}