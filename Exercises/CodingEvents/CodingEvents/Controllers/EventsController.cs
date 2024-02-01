using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    [Route("event")]
    public class EventsController : Controller
    {
        //private static List<string> Events = new List<string>(); //{ "Tom's Event", "Danny's Event", "Mark's Event" };
        //private static Dictionary<string, string> Events = new Dictionary<string, string>();
        //static private List<Event> Events = new List<Event>();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //List<string> Events = new List<string>() { "Tom's Event", "Danny's Event", "Mark's Event" };
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult NewEvent(Event freshEvent)
        {
            EventData.Add(freshEvent);

            return Redirect("/event");
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteProcessing(int[] eventIds)
        {
            foreach (int i in eventIds)
            {
                EventData.Remove(i);
            }

            return Redirect("/event");
        }

        [HttpGet]
        [Route("edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event singleEvent = EventData.GetById(eventId);
            ViewBag.title = "Edit Event " + singleEvent.Name + "(id=" + singleEvent.Id.ToString() + ")";
            ViewBag.singleEvent = singleEvent;

            return View();
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditProcessing(int eventId, string name, string description)
        {
            Event editEvent = EventData.GetById(eventId);
            editEvent.Name = name;
            editEvent.Description = description;
            //EventData.Save(editEvent); // this would be needed if we were connected to a db, but in this case, we are just updating the object itself
            return Redirect("/event");
        }
    }
}
