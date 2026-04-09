using System.Windows;
using System.Windows.Media.Animation;

namespace CinemaApp.Views
{
    public partial class BookingWindow : Window
    {
        public BookingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var animation = new DoubleAnimation(0, 1, new System.TimeSpan(0, 0, 0, 0, 350));
            BeginAnimation(OpacityProperty, animation);
        }
    }
}