using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;
using CIS174_M06RazorTemplates.Repositories;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository data;

        public TicketsController(ITicketRepository rep)
        {
            data = rep;
        }

        public IActionResult Index()
        {
            var tickets = data.List();

            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Ticket());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                data.Add(ticket);
                data.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var ticket = data.Get(id);

            if (ticket != null &&
                (status == "To Do" || status == "In Progress" ||
                 status == "QA" || status == "Done"))
            {
                ticket.Status = status;
                data.Save();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var ticket = data.Get(id);

            if (ticket != null)
            {
                data.Delete(ticket);
                data.Save();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}