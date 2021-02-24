namespace Lab3
{
    public class CalendarType
    {
        private string Type { get; set; }

        public CalendarType(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}