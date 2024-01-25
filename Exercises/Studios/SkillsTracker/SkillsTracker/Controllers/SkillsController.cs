using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker.Controllers
{
    [Route("skills")]
    public class SkillsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<h1> Skills Tracker</h1>" +
                "<ol> <li>Java</li><li>C#</li><li>Python</li></ol>";
            return Content(html, "text/html");
        }

        //GET: skills/form
        [HttpGet("form")]
        public IActionResult DisplayForm()
        {
            string html = "<h1>What is your favorite programming language?</h1><form method='post' action='/skills/form'>" +
   "<input type='text' name='language' />" +
   "<input type='submit' value='My Favorite!' />" +
   "</form>";
            return Content(html, "text/html");
        }

        //POST: /skills/form
        [HttpPost("form")]
        public IActionResult RenderForm(string language)
        {
            string html = "You chose " + language;
            return Content(html, "text/html");
        }
    }
}
