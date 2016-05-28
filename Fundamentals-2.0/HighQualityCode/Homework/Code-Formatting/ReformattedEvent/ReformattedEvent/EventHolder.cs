namespace ReformattedEvent
{
    using System;

    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> eventsByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsByDate.Add(newEvent);

            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();

            int removed = 0;
            foreach (Event eventToRemove in this.eventsByTitle[title])
            {
                removed++;
                this.eventsByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            int showedEvents = 0;
            foreach (Event eventToShow in eventsToShow)
            {
                if (showedEvents == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showedEvents++;
            }

            if (showedEvents == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
