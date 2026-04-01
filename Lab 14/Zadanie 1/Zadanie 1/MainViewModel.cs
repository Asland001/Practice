using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CinemaApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieSession> Sessions { get; set; }

        private MovieSession selectedSession;
        public MovieSession SelectedSession
        {
            get => selectedSession;
            set
            {
                selectedSession = value;
                OnPropertyChanged(nameof(SelectedSession));
            }
        }

        private int ticketCount;
        public int TicketCount
        {
            get => ticketCount;
            set
            {
                ticketCount = value;
                OnPropertyChanged(nameof(TicketCount));
            }
        }
        
        public void BuyTickets()
        {
            if (SelectedSession == null)
            {
                MessageBox.Show("Выберите сеанс!");
                return;
            }

            if (TicketCount <= 0)
            {
                MessageBox.Show("Введите корректное количество билетов!");
                return;
            }

            if (TicketCount > SelectedSession.AvailableSeats)
            {
                MessageBox.Show("Недостаточно мест!");
                return;
            }

            //Уменьшаем количество мест
            SelectedSession.AvailableSeats -= TicketCount;

            MessageBox.Show("Билет(ы) успешно заказан!");

            //Сброс количества
            TicketCount = 0;
        }

        public MainViewModel()
        {
            Sessions = new ObservableCollection<MovieSession>()
            {
                new MovieSession { MovieName = "Интерстеллар (2014)", Time = "18:00", AvailableSeats = 50 },
                new MovieSession { MovieName = "Побег из Шоушенка (1994)", Time = "20:00", AvailableSeats = 40 },
                new MovieSession { MovieName = "Джентльмены (2019)", Time = "22:00", AvailableSeats = 30 },
                new MovieSession { MovieName = "1+1 (2011)", Time = "12:00", AvailableSeats = 20 },
                new MovieSession { MovieName = "Остров проклятых (2009)", Time = "15:00", AvailableSeats = 41 },
                new MovieSession { MovieName = "Терминатор 2: Судный день (1991)", Time = "00:00", AvailableSeats = 21 },
                new MovieSession { MovieName = "Бойцовский клуб (1999)", Time = "17:00", AvailableSeats = 23}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}