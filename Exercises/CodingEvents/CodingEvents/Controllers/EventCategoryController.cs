using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingEvents.Controllers
{
    [Route("eventcategory")]
    public class EventCategoryController : Controller
    {
        EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.EventCategories.ToList();
            foreach (EventCategory eventCategory in eventCategories)
            {
                Debug.WriteLine(eventCategory.ToString());
            }

            return View("Index", eventCategories);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View("Create", new AddEventCategoryViewModel());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult ProcessCreate(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name
                };
                context.EventCategories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/eventcategory");
            }
            return View("Create", addEventCategoryViewModel);
        }
    }
}
