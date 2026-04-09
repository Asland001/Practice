using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaApp.Models
{
    public class TicketModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        private MovieSession session;
        public MovieSession Session
        {
            get => session;
            set
            {
                session = value;
                OnPropertyChanged();
            }
        }

        private string movieName;
        public string MovieName
        {
            get => movieName;
            set
            {
                movieName = value;
                OnPropertyChanged();
            }
        }

        private string sessionTime;
        public string SessionTime
        {
            get => sessionTime;
            set
            {
                sessionTime = value;
                OnPropertyChanged();
            }
        }

        private int seatCount;
        public int SeatCount
        {
            get => seatCount;
            set
            {
                seatCount = value;
                OnPropertyChanged();
            }
        }

        private string buyerLogin;
        public string BuyerLogin
        {
            get => buyerLogin;
            set
            {
                buyerLogin = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}