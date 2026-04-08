using CinemaApp.Models;
using CinemaApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        private readonly CinemaService cinemaService = new CinemaService();
        private readonly NotificationService notificationService = new NotificationService();

        public ObservableCollection<SeatModel> Seats { get; }
        public ICommand BookSeatCommand { get; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public CinemaViewModel()
        {
            Seats = new ObservableCollection<SeatModel>();

            for (int i = 1; i <= 20; i++)
                Seats.Add(new SeatModel { Number = i });

            BookSeatCommand = new RelayCommand(async seat =>
            {
                await BookSeatAsync(seat as SeatModel);
            });
        }

        private async Task BookSeatAsync(SeatModel seat)
        {
            if (seat == null)
            {
                MessageBox.Show("Выберите место.");
                return;
            }

            if (seat.IsBooked)
            {
                MessageBox.Show("Место уже занято.");
                return;
            }

            IsBusy = true;

            bool success = await cinemaService.BookSeatAsync(seat);

            IsBusy = false;

            if (success)
            {
                await cinemaService.SaveCinemaAsync(Seats);
                notificationService.Send($"Место {seat.Number} забронировано");
                MessageBox.Show("Бронирование успешно.");
            }
            else
            {
                MessageBox.Show("Не удалось забронировать место.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}