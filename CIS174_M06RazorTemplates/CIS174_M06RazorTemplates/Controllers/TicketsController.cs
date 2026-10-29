using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class TicketsController : Controller
    {
        private const string TicketsKey = "tickets";

        private List<Ticket> GetTickets()
        {
            return HttpContext.Session.GetObject<List<Ticket>>(TicketsKey) ?? new List<Ticket>();
        }

        private void SaveTickets(List<Ticket> tickets)
        {
            HttpContext.Session.SetObject(TicketsKey, tickets);
        }

        public IActionResult Index()
        {
            var tickets = GetTickets()
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
                var tickets = GetTickets();

                ticket.Id = tickets.Count == 0 ? 1 : tickets.Max(t => t.Id) + 1;

                tickets.Add(ticket);
                SaveTickets(tickets);

                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var tickets = GetTickets();

            var ticket = tickets.FirstOrDefault(t => t.Id == id);

            if (ticket != null &&
                (status == "To Do" ||
                 status == "In Progress" ||
                 status == "QA" ||
                 status == "Done"))
            {
                ticket.Status = status;
                SaveTickets(tickets);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var tickets = GetTickets();

            var ticket = tickets.FirstOrDefault(t => t.Id == id);

            if (ticket != null)
            {
                tickets.Remove(ticket);
                SaveTickets(tickets);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}