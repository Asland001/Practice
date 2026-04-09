using CinemaApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
                await vm.InitializeAsync();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (DataContext is IDisposable disposable)
                disposable.Dispose();
        }
    }
}