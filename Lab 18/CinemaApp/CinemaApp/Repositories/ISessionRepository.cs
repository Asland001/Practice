using CinemaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApp.Repositories
{
    public interface ISessionRepository
    {
        Task<List<MovieSession>> GetAllAsync();
        Task<MovieSession> GetByIdAsync(int id);
        void Add(MovieSession session);
        void AddRange(IEnumerable<MovieSession> sessions);
        void Update(MovieSession session);
        void Remove(MovieSession session);
    }
}