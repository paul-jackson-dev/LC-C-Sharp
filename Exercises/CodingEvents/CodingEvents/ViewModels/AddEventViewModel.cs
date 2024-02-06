using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name of event is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "An event name should be 3 - 50 characters")]
        public string? Name { get; set; } //? makes this property nullable

        [Required(ErrorMessage = "Description of event is required.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "An event name should be 3 - 50 characters")]
        public string? Description { get; set; }

        [EmailAddress] // checks formatting with built-in error messages
        public string? Email { get; set; }

        [Required(ErrorMessage = "Location of event is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "An event location should be 3 - 50 characters")]
        public string? Location { get; set; }

        // no contructor required for ViewModels, similar to DTO
    }
}
