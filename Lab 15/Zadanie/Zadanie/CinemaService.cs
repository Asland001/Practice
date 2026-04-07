using System.Threading.Tasks;

namespace CinemaApp
{
    public class CinemaService
    {
        public async Task<bool> BookSeatAsync(SeatModel seat)
        {
            //Имитация запроса
            await Task.Delay(2000);

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            return true;
        }
    }
}