using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaApp.Models
{
    public class MovieSession : INotifyPropertyChanged
    {
        public int Id { get; set; }

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

        private string time;
        public string Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }

        private int availableSeats;
        public int AvailableSeats
        {
            get => availableSeats;
            set
            {
                availableSeats = value;
                OnPropertyChanged();
            }
        }

        public ICollection<TicketModel> Tickets { get; set; } = new List<TicketModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}