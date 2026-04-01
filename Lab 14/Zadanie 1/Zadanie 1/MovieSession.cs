using System.ComponentModel;

namespace CinemaApp
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
                availableSeats = value;
                OnPropertyChanged(nameof(AvailableSeats));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}