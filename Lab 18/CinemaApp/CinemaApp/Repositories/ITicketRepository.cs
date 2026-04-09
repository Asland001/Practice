using CinemaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApp.Repositories
{
    public interface ITicketRepository
    {
        Task<List<TicketModel>> GetAllAsync();
        Task<TicketModel> GetByIdAsync(int id);
        void Add(TicketModel ticket);
        void AddRange(IEnumerable<TicketModel> tickets);
        void Update(TicketModel ticket);
        void Remove(TicketModel ticket);
    }
}