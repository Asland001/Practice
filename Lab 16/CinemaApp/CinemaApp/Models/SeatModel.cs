using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaApp.Models
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
                if (isBooked == value) return;
                isBooked = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public string StatusText => IsBooked ? "Занято" : "Свободно";

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}