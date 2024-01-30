using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    [Route("event")]
    public class EventsController : Controller
    {
        //private static List<string> Events = new List<string>(); //{ "Tom's Event", "Danny's Event", "Mark's Event" };
        private static Dictionary<string, string> Events = new Dictionary<string, string>();


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //List<string> Events = new List<string>() { "Tom's Event", "Danny's Event", "Mark's Event" };
            ViewBag.events = Events;

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
        public IActionResult NewEvent(string name, string description)
        {
            Events.Add(name, description);

            return Redirect("/event");
        }
    }
}
