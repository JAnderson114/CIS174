using CIS174_M05Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CIS174_M05Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DefaultRouting()
        {
            return View();
        }

        public IActionResult CustomRouting()
        {
            return View();
        }

        [Route("attribute-routing")]
        public IActionResult AttributeRouting()
        {
            return View();
        }
    }
}
