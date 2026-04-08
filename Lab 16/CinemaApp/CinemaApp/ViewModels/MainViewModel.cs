using CinemaApp.Models;
using CinemaApp.Services;
using CinemaApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CinemaService cinemaService = new CinemaService();

        public ObservableCollection<MovieSession> Sessions { get; }
        public ICollectionView SessionsView { get; }

        private MovieSession selectedSession;
        public MovieSession SelectedSession
        {
            get => selectedSession;
            set
            {
                selectedSession = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedMovieName));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private int ticketCount;
        public int TicketCount
        {
            get => ticketCount;
            set
            {
                ticketCount = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string timeFilter;
        public string TimeFilter
        {
            get => timeFilter;
            set
            {
                timeFilter = value;
                OnPropertyChanged();
            }
        }

        public string SelectedMovieName => SelectedSession?.MovieName ?? string.Empty;

        public ICommand BookTicketCommand { get; }
        public ICommand BuyTicketCommand { get; }
        public ICommand EditTicketCommand { get; }
        public ICommand CancelTicketCommand { get; }
        public ICommand ApplyFilterCommand { get; }
        public ICommand ResetFilterCommand { get; }

        public MainViewModel()
        {
            Sessions = new ObservableCollection<MovieSession>
            {
                new MovieSession { MovieName = "Интерстеллар", Time = "18:00", AvailableSeats = 50 },
                new MovieSession { MovieName = "Матрица", Time = "20:00", AvailableSeats = 40 },
                new MovieSession { MovieName = "Джентльмены", Time = "22:00", AvailableSeats = 30 },
                new MovieSession { MovieName = "1+1", Time = "12:00", AvailableSeats = 20 },
                new MovieSession { MovieName = "Остров проклятых", Time = "15:00", AvailableSeats = 25 }
            };

            SessionsView = CollectionViewSource.GetDefaultView(Sessions);
            SessionsView.Filter = FilterSession;

            SelectedSession = Sessions[0];

            BookTicketCommand = new RelayCommand(_ =>
            {
                var window = new BookingWindow();
                window.ShowDialog();
            });

            BuyTicketCommand = new RelayCommand(async _ => await BuyTicketsAsync(), _ => SelectedSession != null);
            EditTicketCommand = new RelayCommand(_ => EditBooking(), _ => SelectedSession != null);
            CancelTicketCommand = new RelayCommand(_ => CancelBooking(), _ => SelectedSession != null);

            ApplyFilterCommand = new RelayCommand(_ => SessionsView.Refresh());
            ResetFilterCommand = new RelayCommand(_ =>
            {
                TimeFilter = string.Empty;
                OnPropertyChanged(nameof(TimeFilter));
                SessionsView.Refresh();
            });
        }

        private bool FilterSession(object obj)
        {
            if (obj is not MovieSession session)
                return false;

            if (string.IsNullOrWhiteSpace(TimeFilter))
                return true;

            return session.Time != null && session.Time.Contains(TimeFilter);
        }

        private async System.Threading.Tasks.Task BuyTicketsAsync()
        {
            if (SelectedSession == null)
            {
                MessageBox.Show("Выберите сеанс.");
                return;
            }

            if (TicketCount <= 0)
            {
                MessageBox.Show("Введите количество билетов.");
                return;
            }

            if (TicketCount > SelectedSession.AvailableSeats)
            {
                MessageBox.Show("Недостаточно мест.");
                return;
            }

            SelectedSession.AvailableSeats -= TicketCount;
            await cinemaService.SaveCinemaAsync(Sessions);

            MessageBox.Show("Билет(ы) успешно куплены.");
            TicketCount = 0;
        }

        private void EditBooking()
        {
            MessageBox.Show("");
        }

        private void CancelBooking()
        {
            if (SelectedSession == null)
                return;

            var result = MessageBox.Show("Отменить бронь?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
                return;

            int restoreCount = TicketCount > 0 ? TicketCount : 1;
            SelectedSession.AvailableSeats += restoreCount;

            MessageBox.Show("Бронь отменена.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}