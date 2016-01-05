namespace ReformattedEvent
{
    using System.Text;

    public static class Messages
    {
        public static readonly StringBuilder Output = new StringBuilder();

        public static void EventAdded()
        {
            Output.AppendLine("Event added");
        }

        public static void EventDeleted(int count)
        {
            if (count == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendLine($"{count} Events deleted");
            }
        }

        public static void NoEventsFound()
        {
            Output.AppendLine("No Events found");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.AppendLine(eventToPrint.ToString());
            }
        }
    }
}
