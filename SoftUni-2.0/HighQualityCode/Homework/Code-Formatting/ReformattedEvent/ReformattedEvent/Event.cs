namespace ReformattedEvent
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private readonly string title;
        private readonly string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            int result = 0;

            Event other = obj as Event;

            int byDate = this.date.CompareTo(other?.date);
            int byTitle = string.Compare(this.title, other?.title, StringComparison.Ordinal);
            int byLocation = string.Compare(this.location, other?.location, StringComparison.Ordinal);

            if (byDate == 0)
            {
                result = byTitle;
            }
            else if (byTitle == 0)
            {
                result = byLocation;
            }
            else if (byLocation == 0)
            {
                result = byDate;
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            output.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                output.Append(" | " + this.location);
            }

            return output.ToString();
        }
    }
}