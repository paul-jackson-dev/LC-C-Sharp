using CodingEvents.Models;

namespace CodingEvents.ViewModels
{
    public class EventDetailViewModel
    {

        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }

        public string TagText { get; set; }
        //List<Tag> Tags { get; set; }

        public EventDetailViewModel(Event anEvent)
        {

            EventId = anEvent.Id;
            Name = anEvent.Name;
            Description = anEvent.Description;
            ContactEmail = anEvent.Email;
            CategoryName = anEvent.Category.Name; // store this objects Name property as a string

            List<Tag> tags = anEvent.Tags.ToList();
            TagText = "";
            foreach (Tag tag in tags)
            {
                TagText += ("#" + tag.Name + ", ");
            }
            TagText = TagText.TrimEnd(' '); // could use substring
            TagText = TagText.TrimEnd(',');
        }
    }
}
