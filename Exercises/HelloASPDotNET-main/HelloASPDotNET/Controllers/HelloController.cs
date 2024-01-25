using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/hello")]
    public class HelloController : Controller
    {
        // GET: /hello/
        [HttpGet]
        public IActionResult Index()
        {

            string html = "<form method='post' action = 'hello/welcome'>" +
                "<input type='text' name='name' />" +
                "<select name='language'><option value='english' selected>English</option>" +
                "<option value='spanish'>Spanish</spanish>" +
                "<option value='bosnian'>Bosnian</option>" +
                "<option value='vietnamese'>Vietnamese</option>" +
                "<option value='french'>French</option></select>" +
                "<input type='submit' value='Greet Me!'/>" +
                "</form>";

            return Content(html, "text/html");
        }

        //// GET : /<controller>/welcome
        //[HttpGet("welcome/{name?}")]
        //public IActionResult Welcome(string name = "no name given")
        //{
        //    string html = "<h1>" + "Hi! " + name + "</h1>";
        //    return Content(html, "text/html");
        //}

        // POST: /<controller>/welcome
        //GET : /<controller>/welcome/{name}
        [HttpPost("welcome")] // responds to post request at /hello/welcome
        [HttpGet("welcome/{name?}")] // responds to get request at /hello/welcome/{name}
        public IActionResult WelcomePost(string name = "no name given", string language = "english")
        {
            language = char.ToUpper(language[0]) + language.Substring(1); // convert first letter to Uppercase
            string html = "<h1>" + "Hi! " + name + " in " + language + "</ h1 > ";
            return Content(html, "text/html");
        }
    }
}
