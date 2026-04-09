using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaApp.Models
{
    public class MovieSession : INotifyPropertyChanged
    {
        public string MovieName { get; set; }
        public string Time { get; set; }

        private int availableSeats;
        public int AvailableSeats
        {
            get => availableSeats;
            set
            {
                if (availableSeats == value) return;
                availableSeats = value;
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