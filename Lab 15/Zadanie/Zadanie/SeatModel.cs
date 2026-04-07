using System.ComponentModel;

namespace CinemaApp
{
    public class SeatModel : INotifyPropertyChanged
    {
        public int Number { get; set; }

        private bool isBooked;
        public bool IsBooked
        {
            get => isBooked;
            set
            {
                isBooked = value;
                OnPropertyChanged(nameof(IsBooked));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}