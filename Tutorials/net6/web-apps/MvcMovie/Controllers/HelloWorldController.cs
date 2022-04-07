using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        ////Get: /helloworld/index/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        public IActionResult Index()
        {
            return View();
        }

        //Get: /helloworld/welcome
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        public string Welcome2(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, Numtimes is:{numTimes}");
        }

        public string Welcome3(string name, int Id = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name},ID:{Id}");
        }

        public IActionResult Welcome4(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
