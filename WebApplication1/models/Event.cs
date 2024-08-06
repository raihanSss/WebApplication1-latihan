namespace WebApplication1.models
{
    public class Event
    {
        public int id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int MaxAttendees { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

    }
}
