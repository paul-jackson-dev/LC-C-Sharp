using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodingEvents.Controllers
{
    [Route("tag")]
    public class TagController : Controller
    {
        EventDbContext context;

        public TagController(EventDbContext dbContext)
        {
            this.context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View("Index", tags);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View("Add", tag);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult ProcessAdd(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", tag);

            }
            context.Tags.Add(tag);
            context.SaveChanges();
            return Redirect("/tag"); // save changes and redirect to display all tags
        }

        [HttpGet]
        [Route("addevent/{id}")] //tag/addevent/5
        public IActionResult AddEvent(int id)
        {
            Event anEvent = context.Events.Find(id);
            List<Tag> tags = context.Tags.ToList();
            AddEventTagViewModel addEventTagViewModel = new AddEventTagViewModel(anEvent, tags);

            return View("AddEvent", addEventTagViewModel);
        }

        [HttpPost]
        [Route("addevent")]
        public IActionResult ProcessAddEvent(AddEventTagViewModel addEventTagViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEvent", addEventTagViewModel);
            }

            int eventId = addEventTagViewModel.EventId;
            int tagId = addEventTagViewModel.TagId;

            Event anEvent = context.Events
                .Include(e => e.Tags) // use include method for eager loading to include tags
                .Where(e => e.Id == eventId) // find our event
                .First(); //

            Tag aTag = context.Tags
                .Where(t => t.Id == tagId)
                .First();

            anEvent.Tags.Add(aTag); // add the tag to event
            context.SaveChanges(); // save all changes


            return Redirect("/event/detail/" + eventId);
        }

        [HttpGet]
        [Route("detail/{id}")]
        public IActionResult Detail(int id)
        {
            Tag aTag = context.Tags
                .Include(t => t.Events)
                .Where(t => t.Id == id)
                .First();

            return View("Detail", aTag);
        }
    }
}
