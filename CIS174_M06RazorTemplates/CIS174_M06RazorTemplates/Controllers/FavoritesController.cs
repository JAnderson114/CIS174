using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);

            return View(session.GetFavorites());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            session.ClearFavorites();

            TempData["message"] = "Favorites cleared.";

            return RedirectToAction(nameof(Index));
        }
    }
}