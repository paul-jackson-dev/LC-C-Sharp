using CodingEvents.Models;

namespace CodingEvents.Data
{
    public class EventData
    {

        //public static List<Event> Events = new List<Event>();
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();

        //EventData() { }

        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        public static void Add(Event e) { Events.Add(e.Id, e); }

        public static void Remove(int id) { Events.Remove(id); } // pass in id of an event from a form

        public static void Save(Event e)
        {
            Events[e.Id].Name = e.Name;
            Events[e.Id].Description = e.Description;
        }

        public static Event GetById(int id) { return Events[id]; }

    }
}
