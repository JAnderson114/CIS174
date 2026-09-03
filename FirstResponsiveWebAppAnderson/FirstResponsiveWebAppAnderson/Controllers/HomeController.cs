using Microsoft.AspNetCore.Mvc;
using FirstResponsiveWebAppLastName.Models;

namespace FirstResponsiveWebAppLastName.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = user.Name +
                    ", you will be " + user.AgeThisYear() +
                    " years old on December 31st of this year.";
            }

            return View(user);
        }
    }
}