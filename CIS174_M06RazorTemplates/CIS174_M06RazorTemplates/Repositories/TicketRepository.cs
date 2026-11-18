using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketsContext context;

        public TicketRepository(TicketsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Ticket> List()
        {
            return context.Tickets
              .OrderBy(t => t.Id)
              .ToList();
        }

        public Ticket? Get(int id)
        {
            return context.Tickets.Find(id);
        }

        public void Add(Ticket ticket)
        {
            context.Tickets.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            context.Tickets.Remove(ticket);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}