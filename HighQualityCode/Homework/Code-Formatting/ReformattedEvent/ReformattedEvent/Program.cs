namespace ReformattedEvent
{
    using System;

    public static class Program
    {
        private static readonly EventHolder Events = new EventHolder();

        public static void Main(string[] args)
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (command == null)
            {
                return false;
            }

            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    return true;

                case 'D':
                    DeleteEvents(command);
                    return true;

                case 'L':
                    ListEvents(command);
                    return true;

                case 'E':
                    return false;

                default:
                    return false;
            }
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");

            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            Events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            Events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, "AddEvent", out date, out title, out location);

            Events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string command,
            string commandType,
            out DateTime date,
            out string eventTitle,
            out string eventLocation)
        {
            date = GetDate(command, commandType);
            int firstPipeIndex = command.IndexOf('|');
            int lastPipeIndex = command.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = command.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = command.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = command.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}