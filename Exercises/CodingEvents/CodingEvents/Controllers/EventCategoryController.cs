using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View("Index", eventCategories);
        }
    }
}
