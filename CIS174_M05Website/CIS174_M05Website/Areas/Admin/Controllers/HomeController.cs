using Microsoft.AspNetCore.Mvc;

namespace CIS174_M05Website.Controllers.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
