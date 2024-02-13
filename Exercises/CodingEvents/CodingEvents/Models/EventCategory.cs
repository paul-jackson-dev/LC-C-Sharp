namespace CodingEvents.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Event> Events { get; set; } // make EventCategory aware of db connection with Events
        //The new property on Event is a single EventCategory reference, while the new property on EventCategory is a collection of Event objects. This is due to the one-to-many nature of the relationship. Each Event can have only one EventCategory, but an EventCategory may be related to multiple Event objects.


        public EventCategory() { }

        public EventCategory(string name) { Name = name; }
    }
}
