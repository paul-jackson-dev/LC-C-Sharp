
namespace CodingEvents.Models
{
    public class Event
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public EventType? Type { get; set; }
        public int Id { get; }
        private static int nextId = 1;

        public Event()
        { // empty constructor required for model binding
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description, string? email, string? location)
        {
            Name = name;
            Description = description;
            Email = email;
            Location = location;
            Id = nextId;
            nextId++;
        }

        public override string? ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
