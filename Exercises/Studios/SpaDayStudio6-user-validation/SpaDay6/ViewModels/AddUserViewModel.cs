using System.ComponentModel.DataAnnotations;

namespace SpaDay6.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 - 15 characters.")]
        public string? Username { get; set; }

        [EmailAddress(ErrorMessage = "required")] // use default error messages
        public string? Email { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "required")]
        public string? Verify { get; set; }
    }
}
