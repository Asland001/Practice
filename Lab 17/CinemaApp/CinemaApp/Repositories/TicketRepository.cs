using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext _context;

        public TicketRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public Task<List<TicketModel>> GetAllAsync()
        {
            return _context.Tickets
                .Include(t => t.Session)
                .OrderBy(t => t.Id)
                .ToListAsync();
        }

        public Task<TicketModel> GetByIdAsync(int id)
        {
            return _context.Tickets
                .Include(t => t.Session)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Add(TicketModel ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void AddRange(IEnumerable<TicketModel> tickets)
        {
            _context.Tickets.AddRange(tickets);
        }

        public void Update(TicketModel ticket)
        {
            _context.Tickets.Update(ticket);
        }

        public void Remove(TicketModel ticket)
        {
            _context.Tickets.Remove(ticket);
        }
    }
}