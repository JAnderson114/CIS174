using Microsoft.EntityFrameworkCore;

namespace CIS174_M06RazorTemplates.Models
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions<TicketsContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; } = null!;
    }
}