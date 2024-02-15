using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Controllers
{
    [Route("event")]
    public class EventsController : Controller
    {
        //private static List<string> Events = new List<string>(); //{ "Tom's Event", "Danny's Event", "Mark's Event" };
        //private static Dictionary<string, string> Events = new Dictionary<string, string>();
        //static private List<Event> Events = new List<Event>();
        private EventDbContext context;

        public EventsController(EventDbContext dbcontext) // use contructor injection to populate context with our Entity
        {
            context = dbcontext;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //List<string> Events = new List<string>() { "Tom's Event", "Danny's Event", "Mark's Event" };
            //ViewBag.events = EventData.GetAll();
            //List<Event> events = new List<Event>(EventData.GetAll());
            //List<Event> events = context.Events.ToList();
            List<Event> events = context.Events.Include(e => e.Category).ToList(); // eager loading, performs join operation adding Category

            return View(events); // when sending a list directly to the view, we need to import the event model and  @model List<Event> for strong typing
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            List<EventCategory> categories = context.EventCategories.ToList(); // get all categories
            AddEventViewModel viewModel = new AddEventViewModel(categories); // pass them to the viewmodel so they can be rendered into a select item list
            return View(viewModel); // return viewmodel to page for rending
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid) // if Model is valid and there are no error messages.
            {
                EventCategory? aCategory = context.EventCategories.Find(addEventViewModel.CategoryId); // get the Category using the Id
                //Event newEvent = new Event(addEventViewModel.Name, addEventViewModel.Description);
                Event freshEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Email = addEventViewModel.Email,
                    Location = addEventViewModel.Location,
                    //Type = addEventViewModel.Type
                    Category = aCategory
                };


                //EventData.Add(freshEvent);
                context.Events.Add(freshEvent);
                context.SaveChanges();

                return Redirect("/event");
            }
            return View(addEventViewModel); // there are errors, return the addEventViewModel
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteProcessing(int[] eventIds)
        {
            foreach (int i in eventIds)
            {
                //EventData.Remove(i);
                Event? anEvent = context.Events.Find(i);
                if (anEvent != null)
                {
                    context.Events.Remove(anEvent);
                    context.SaveChanges();
                }
            }

            return Redirect("/event");
        }

        [HttpGet]
        [Route("edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //Event singleEvent = EventData.GetById(eventId);
            Event? singleEvent = context.Events.Find(eventId);
            if (singleEvent != null)
            {
                ViewBag.title = "Edit Event " + singleEvent.Name + "(id=" + singleEvent.Id.ToString() + ")";
                ViewBag.singleEvent = singleEvent;
            }

            return View();
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditProcessing(int eventId, string name, string description)
        {
            //Event editEvent = EventData.GetById(eventId);
            Event? editEvent = context.Events.Find(eventId);
            if (editEvent != null)
            {
                editEvent.Name = name;
                editEvent.Description = description;
                context.SaveChanges();
                //EventData.Save(editEvent); // this would be needed if we were connected to a db, but in this case, we are just updating the object itself
            }
            return Redirect("/event");
        }

        [HttpGet]
        [Route("detail/{id}")] //event/detail/5
        public IActionResult Detail(int id) // this needs to be id because of app.MapControllerRoute in Program.cs pattern: "{controller=Home}/{action=Index}/{id?}");
        {
            Event anEvent = context.Events
                .Include(e => e.Category) // include Category one to many
                .Include(e => e.Tags) // include tags many to many
                .Single(e => e.Id == id); // return a single entry where e.Id == id // can't use Find() becase we are eager loading to include Category

            EventDetailViewModel viewModel = new EventDetailViewModel(anEvent);
            return View("detail", viewModel);
        }
    }
}
