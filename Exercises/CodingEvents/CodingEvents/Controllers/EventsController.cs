using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            List<Event> events = context.Events.ToList();

            return View(events); // when sending a list directly to the view, we need to import the event model and  @model List<Event> for strong typing
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            AddEventViewModel viewModel = new AddEventViewModel();
            return View(viewModel); // return viewmodel to page for rending
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid) // if Model is valid and there are no error messages.
            {
                //Event newEvent = new Event(addEventViewModel.Name, addEventViewModel.Description);
                Event freshEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Email = addEventViewModel.Email,
                    Location = addEventViewModel.Location,
                    Type = addEventViewModel.Type
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
    }
}
