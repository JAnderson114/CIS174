using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketsContext context;

        public TicketsController(TicketsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var tickets = context.Tickets
                .OrderBy(t => t.Id)
                .ToList();

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
                context.Tickets.Add(ticket);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(ticket);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var ticket = context.Tickets.Find(id);

            if (ticket != null &&
                (status == "To Do" || status == "In Progress" ||
                 status == "QA" || status == "Done"))
            {
                ticket.Status = status;
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var ticket = context.Tickets.Find(id);

            if (ticket != null)
            {
                context.Tickets.Remove(ticket);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}