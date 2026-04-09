using CinemaApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace CinemaApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not LoginViewModel vm)
                return;

            var password = PasswordBox.Password?.Trim();

            if (vm.TryLogin(password, out string message))
            {
                MessageBox.Show(message);
                await SmoothTransitionToMainAsync();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not LoginViewModel vm)
                return;

            var password = PasswordBox.Password?.Trim();

            if (vm.TryRegister(password, out string message))
            {
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private async Task SmoothTransitionToMainAsync()
        {
            var mainWindow = new MainWindow
            {
                Opacity = 0,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            mainWindow.Show();

            var fadeIn = AnimateOpacityAsync(mainWindow, 0, 1, 350);
            var fadeOut = AnimateOpacityAsync(this, 1, 0, 350);

            await Task.WhenAll(fadeIn, fadeOut);

            Close();
        }

        private Task AnimateOpacityAsync(Window window, double from, double to, int milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();

            var animation = new DoubleAnimation(from, to, TimeSpan.FromMilliseconds(milliseconds));
            animation.Completed += (_, _) => tcs.TrySetResult(true);

            window.BeginAnimation(OpacityProperty, animation);

            return tcs.Task;
        }
    }
}