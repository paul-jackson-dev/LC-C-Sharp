using System.ComponentModel.DataAnnotations;

namespace CodingEvents.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of Tag is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name of Tag must be between 3 and 50 characters")]
        public string Name { get; set; }

        public Tag() { } //no arg for model binding

        public ICollection<Event>? Events { get; set; }  //many to many?

        public Tag(string name)
        {
            Name = name;
        }
    }
}
