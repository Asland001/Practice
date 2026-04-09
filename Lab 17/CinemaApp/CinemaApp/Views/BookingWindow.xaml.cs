using CinemaApp.Models;
using CinemaApp.ViewModels;
using System.Windows;
using System.Windows.Media.Animation;

namespace CinemaApp.Views
{
    public partial class BookingWindow : Window
    {
        public BookingWindow(MovieSession session = null)
        {
            InitializeComponent();
            DataContext = new CinemaViewModel(session);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fade = new DoubleAnimation(0, 1, System.TimeSpan.FromMilliseconds(350));
            BeginAnimation(OpacityProperty, fade);
        }
    }
}