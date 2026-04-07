using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp
{
    public class CinemaViewModel
    {
        public ObservableCollection<SeatModel> Seats { get; set; }

        public ICommand BookSeatCommand { get; set; }

        private CinemaService service = new CinemaService();

        public CinemaViewModel()
        {
            Seats = new ObservableCollection<SeatModel>();
            
            for (int i = 1; i <= 150; i++)
            {
                Seats.Add(new SeatModel { Number = i });
            }

            BookSeatCommand = new RelayCommand(async (seat) =>
            {
                await BookSeat(seat as SeatModel);
            });
        }

        private async Task BookSeat(SeatModel seat)
        {
            if (seat == null) return;

            bool success = await service.BookSeatAsync(seat);

            if (success)
                MessageBox.Show($"Место {seat.Number} успешно забронировано!");
            else
                MessageBox.Show("Место уже занято!");
        }
    }
}