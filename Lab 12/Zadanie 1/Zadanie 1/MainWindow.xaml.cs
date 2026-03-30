using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaApp
{
    public partial class MainWindow : Window
    {
        private const int Rows = 5;
        private const int Columns = 8;

        private List<Button> selectedSeats = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
            CreateSeats();
        }

        //Загрузка фильмов
        private void LoadMovies()
        {
            MovieComboBox.Items.Add("Побег из Шоушенка");
            MovieComboBox.Items.Add("Крестный отец");
            MovieComboBox.Items.Add("Темный рыцарь ");
            MovieComboBox.Items.Add("12 разгневанных мужчин");
            MovieComboBox.Items.Add("Список Шиндлера");
            MovieComboBox.Items.Add("Криминальное чтиво");
            MovieComboBox.Items.Add("Властелин колец: Возвращение короля");
            MovieComboBox.Items.Add("Властелин колец: Братство Кольца");
            MovieComboBox.Items.Add("Зеленая миля");

            MovieComboBox.SelectedIndex = 0;
        }

        //Создание сетки мест
        private void CreateSeats()
        {
            for (int i = 0; i < Rows; i++)
                SeatsGrid.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < Columns; j++)
                SeatsGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Button seat = new Button
                    {
                        Background = Brushes.LightGray,
                        Margin = new Thickness(5),
                        Tag = "Free"
                    };

                    seat.Click += Seat_Click;

                    Grid.SetRow(seat, i);
                    Grid.SetColumn(seat, j);

                    SeatsGrid.Children.Add(seat);
                }
            }
        }

        //Клик по месту
        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button seat = sender as Button;

            if (seat.Tag.ToString() == "Booked")
                return;

            if (seat.Background == Brushes.LightGray)
            {
                seat.Background = Brushes.Green;
                selectedSeats.Add(seat);
            }
            else
            {
                seat.Background = Brushes.LightGray;
                selectedSeats.Remove(seat);
            }
        }

        //Бронирование
        private void BookSeats_Click(object sender, RoutedEventArgs e)
        {
            foreach (var seat in selectedSeats)
            {
                seat.Background = Brushes.Red;
                seat.Tag = "Booked";
            }

            selectedSeats.Clear();

            MessageBox.Show("Места забронированы!");
        }
    }
}