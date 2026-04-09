using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Repositories;
using CinemaApp.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly CinemaDbContext _context = new CinemaDbContext();
        private readonly ISessionRepository _sessionRepository;
        private readonly ITicketRepository _ticketRepository;

        public ObservableCollection<MovieSession> Sessions { get; } = new ObservableCollection<MovieSession>();
        public ObservableCollection<TicketModel> Tickets { get; } = new ObservableCollection<TicketModel>();

        private MovieSession selectedSession;
        public MovieSession SelectedSession
        {
            get => selectedSession;
            set
            {
                selectedSession = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedMovieName));
            }
        }

        private TicketModel selectedTicket;
        public TicketModel SelectedTicket
        {
            get => selectedTicket;
            set
            {
                selectedTicket = value;
                OnPropertyChanged();
            }
        }

        private int ticketCount = 1;
        public int TicketCount
        {
            get => ticketCount;
            set
            {
                ticketCount = value;
                OnPropertyChanged();
            }
        }

        private string buyerLogin = "user";
        public string BuyerLogin
        {
            get => buyerLogin;
            set
            {
                buyerLogin = value;
                OnPropertyChanged();
            }
        }

        public string SelectedMovieName => SelectedSession?.MovieName ?? string.Empty;

        public ICommand OpenHallCommand { get; }
        public ICommand BookTicketCommand { get; }
        public ICommand EditTicketCommand { get; }
        public ICommand CancelTicketCommand { get; }

        public MainViewModel()
        {
            _sessionRepository = new SessionRepository(_context);
            _ticketRepository = new TicketRepository(_context);

            OpenHallCommand = new RelayCommand(_ =>
            {
                var window = new BookingWindow(SelectedSession);
                window.ShowDialog();
            });

            BookTicketCommand = new RelayCommand(async _ => await BookTicketAsync(), _ => SelectedSession != null);
            EditTicketCommand = new RelayCommand(_ => EditTicket(), _ => SelectedTicket != null);
            CancelTicketCommand = new RelayCommand(async _ => await CancelTicketAsync(), _ => SelectedTicket != null);
        }

        public async Task InitializeAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var sessions = await _sessionRepository.GetAllAsync();
            if (!sessions.Any())
            {
                _sessionRepository.AddRange(new[]
                {
                    new MovieSession { MovieName = "Интерстеллар", Time = "18:00", AvailableSeats = 50 },
                    new MovieSession { MovieName = "Матрица", Time = "20:00", AvailableSeats = 40 },
                    new MovieSession { MovieName = "Джентльмены", Time = "22:00", AvailableSeats = 30 },
                    new MovieSession { MovieName = "1+1", Time = "12:00", AvailableSeats = 20 }
                });

                await _context.SaveChangesAsync();
                sessions = await _sessionRepository.GetAllAsync();
            }

            var tickets = await _ticketRepository.GetAllAsync();

            Sessions.Clear();
            foreach (var session in sessions)
                Sessions.Add(session);

            Tickets.Clear();
            foreach (var ticket in tickets)
                Tickets.Add(ticket);

            SelectedSession = Sessions.FirstOrDefault();
            SelectedTicket = Tickets.FirstOrDefault();
        }

        private async Task BookTicketAsync()
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

            var ticket = new TicketModel
            {
                SessionId = SelectedSession.Id,
                MovieName = SelectedSession.MovieName,
                SessionTime = SelectedSession.Time,
                SeatCount = TicketCount,
                BuyerLogin = BuyerLogin
            };

            SelectedSession.AvailableSeats -= TicketCount;

            _sessionRepository.Update(SelectedSession);
            _ticketRepository.Add(ticket);

            await _context.SaveChangesAsync();

            Sessions.RefreshItem(SelectedSession);
            Tickets.Add(ticket);
            SelectedTicket = ticket;

            TicketCount = 1;
            OnPropertyChanged(nameof(SelectedMovieName));

            MessageBox.Show("Билет(ы) успешно куплены.");
        }

        private void EditTicket()
        {
            if (SelectedTicket == null)
            {
                MessageBox.Show("Выберите бронь.");
                return;
            }

            var window = new EditBookingWindow(this, SelectedTicket);
            window.ShowDialog();
        }

        public async Task SaveEditedTicketAsync(TicketModel editedTicket)
        {
            if (editedTicket == null)
                return;

            var existing = await _ticketRepository.GetByIdAsync(editedTicket.Id);
            if (existing == null)
                return;

            var session = await _sessionRepository.GetByIdAsync(existing.SessionId);
            if (session == null)
                return;

            var diff = editedTicket.SeatCount - existing.SeatCount;
            if (diff > 0 && session.AvailableSeats < diff)
            {
                MessageBox.Show("Недостаточно мест для увеличения брони.");
                return;
            }

            session.AvailableSeats -= diff;

            existing.SeatCount = editedTicket.SeatCount;
            existing.BuyerLogin = editedTicket.BuyerLogin;

            _sessionRepository.Update(session);
            _ticketRepository.Update(existing);

            await _context.SaveChangesAsync();

            await ReloadCollectionsAsync();
            MessageBox.Show("Бронь обновлена.");
        }

        private async Task CancelTicketAsync()
        {
            if (SelectedTicket == null)
            {
                MessageBox.Show("Выберите бронь.");
                return;
            }

            var result = MessageBox.Show("Отменить бронь?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
                return;

            var ticket = await _ticketRepository.GetByIdAsync(SelectedTicket.Id);
            if (ticket == null)
                return;

            var session = await _sessionRepository.GetByIdAsync(ticket.SessionId);
            if (session != null)
            {
                session.AvailableSeats += ticket.SeatCount;
                _sessionRepository.Update(session);
            }

            _ticketRepository.Remove(ticket);

            await _context.SaveChangesAsync();

            await ReloadCollectionsAsync();
            MessageBox.Show("Бронь отменена.");
        }

        private async Task ReloadCollectionsAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            var tickets = await _ticketRepository.GetAllAsync();

            Sessions.Clear();
            foreach (var session in sessions)
                Sessions.Add(session);

            Tickets.Clear();
            foreach (var ticket in tickets)
                Tickets.Add(ticket);

            SelectedSession = Sessions.FirstOrDefault();
            SelectedTicket = Tickets.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    internal static class ObservableCollectionExtensions
    {
        public static void RefreshItem<T>(this ObservableCollection<T> collection, T item)
        {
            var index = collection.IndexOf(item);
            if (index < 0) return;
            collection[index] = item;
        }
    }
}