using System.Windows;
using System.Windows.Input;
using CinemaApp.Commands;

namespace CinemaApp.ViewModels
{
    public class MainViewModel
    {
        public ICommand BookTicketCommand { get; }
        public ICommand EditTicketCommand { get; }
        public ICommand CancelTicketCommand { get; }

        public MainViewModel()
        {
            BookTicketCommand = new RelayCommand(BookTicket);
            EditTicketCommand = new RelayCommand(EditTicket);
            CancelTicketCommand = new RelayCommand(CancelTicket);
        }

        private void BookTicket(object parameter = null)
        {
            MessageBox.Show("Открытие окна бронирования билетов", "Бронирование", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditTicket(object parameter = null)
        {
            MessageBox.Show("Редактирование брони", "Редактирование", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelTicket(object parameter = null)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите отменить бронь?",
                "Подтверждение отмены",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Бронь успешно отменена", "Отмена", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}