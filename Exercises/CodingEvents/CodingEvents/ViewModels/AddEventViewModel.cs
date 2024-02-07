using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public EventType Type { get; set; }


        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem> // for enum
           {
              new SelectListItem(EventType.Party.ToString(), ((int)EventType.Party).ToString()),
              new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
              new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
              new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
              new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
           };

        // no contructor required for ViewModels, similar to DTO
    }
}
