using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> List();
        Ticket? Get(int id);
        void Add(Ticket ticket);
        void Delete(Ticket ticket);
        void Save();
    }
}