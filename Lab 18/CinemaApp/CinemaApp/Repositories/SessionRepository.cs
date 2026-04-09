using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CinemaDbContext _context;

        public SessionRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public Task<List<MovieSession>> GetAllAsync()
        {
            return _context.Sessions
                .Include(s => s.Tickets)
                .OrderBy(s => s.Time)
                .ToListAsync();
        }

        public Task<MovieSession> GetByIdAsync(int id)
        {
            return _context.Sessions
                .Include(s => s.Tickets)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Add(MovieSession session)
        {
            _context.Sessions.Add(session);
        }

        public void AddRange(IEnumerable<MovieSession> sessions)
        {
            _context.Sessions.AddRange(sessions);
        }

        public void Update(MovieSession session)
        {
            _context.Sessions.Update(session);
        }

        public void Remove(MovieSession session)
        {
            _context.Sessions.Remove(session);
        }
    }
}