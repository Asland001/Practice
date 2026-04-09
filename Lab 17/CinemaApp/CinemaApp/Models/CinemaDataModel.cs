using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class CinemaDataModel
    {
        public List<MovieSession> Sessions { get; set; } = new List<MovieSession>();
        public List<TicketModel> Tickets { get; set; } = new List<TicketModel>();
    }
}