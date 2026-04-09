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

        public MovieSession CurrentSession { get; }

        private SeatModel selectedSeat;
        public SeatModel SelectedSeat
        {
            get => selectedSeat;
            set
            {
                selectedSeat = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SeatPopupMessage));
            }
        }

        private bool isSessionPopupVisible;
        public bool IsSessionPopupVisible
        {
            get => isSessionPopupVisible;
            set
            {
                isSessionPopupVisible = value;
                OnPropertyChanged();
            }
        }

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

        public string CurrentSessionTitle => CurrentSession?.MovieName ?? "Сеанс не выбран";
        public string CurrentSessionTime => CurrentSession?.Time ?? "-";
        public int CurrentSessionSeats => CurrentSession?.AvailableSeats ?? 0;

        public string SeatPopupMessage =>
            SelectedSeat == null
                ? "Нажмите на место, чтобы увидеть информацию."
                : $"Сеанс: {CurrentSessionTitle}\nВремя: {CurrentSessionTime}\nМесто №{SelectedSeat.Number}\nСтатус: {(SelectedSeat.IsBooked ? "занято" : "свободно")}";

        public CinemaViewModel(MovieSession currentSession = null)
        {
            CurrentSession = currentSession;

            Seats = new ObservableCollection<SeatModel>();
            for (int i = 1; i <= 20; i++)
                Seats.Add(new SeatModel { Number = i });

            BookSeatCommand = new RelayCommand(async seat =>
            {
                await HandleSeatClickAsync(seat as SeatModel);
            });
        }

        private async Task HandleSeatClickAsync(SeatModel seat)
        {
            if (seat == null)
                return;

            SelectedSeat = seat;
            IsSessionPopupVisible = true;

            _ = HidePopupLaterAsync();

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
                var data = cinemaService.LoadCinema();
                await cinemaService.SaveCinemaAsync(data);

                notificationService.Send($"Место {seat.Number} забронировано");
                MessageBox.Show($"Место {seat.Number} успешно забронировано!");
            }
            else
            {
                MessageBox.Show("Не удалось забронировать место.");
            }
        }

        private async Task HidePopupLaterAsync()
        {
            await Task.Delay(2000);
            IsSessionPopupVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}