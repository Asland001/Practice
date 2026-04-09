using CinemaApp.Models;
using CinemaApp.ViewModels;
using System.Windows;

namespace CinemaApp.Views
{
    public partial class EditBookingWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        private readonly TicketModel _ticket;

        public EditBookingWindow(MainViewModel vm, TicketModel selectedTicket)
        {
            InitializeComponent();

            _mainViewModel = vm;
            _ticket = new TicketModel
            {
                Id = selectedTicket.Id,
                SessionId = selectedTicket.SessionId,
                MovieName = selectedTicket.MovieName,
                SessionTime = selectedTicket.SessionTime,
                SeatCount = selectedTicket.SeatCount,
                BuyerLogin = selectedTicket.BuyerLogin
            };

            DataContext = _ticket;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.SaveEditedTicketAsync(_ticket);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}