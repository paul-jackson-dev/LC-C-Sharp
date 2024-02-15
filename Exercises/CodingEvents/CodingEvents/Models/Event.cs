﻿
namespace CodingEvents.Models
{
    public class Event
    {
        //Id is auto-generated by the Entity Framework
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        //public EventType? Type { get; set; }
        public EventCategory Category { get; set; } // One to Many
        public int CategoryId { get; set; } // functions as a foreign key for Category, auto populated?
        //private static int nextId = 1;
        public ICollection<Tag> Tags { get; set; } // Many to Many

        public Event()
        { // empty constructor required for model binding
            //Id = nextId;
            //nextId++;
        }

        public Event(string name, string description, string? email, string? location)
        {
            Name = name;
            Description = description;
            Email = email;
            Location = location;
            //Id = nextId;
            //nextId++;
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
