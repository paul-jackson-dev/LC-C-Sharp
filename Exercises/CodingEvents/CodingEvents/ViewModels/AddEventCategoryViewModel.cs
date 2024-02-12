using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Event category name required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Event category name must be between 3 - 20 characters.")]
        public string? Name { get; set; }
    }
}
