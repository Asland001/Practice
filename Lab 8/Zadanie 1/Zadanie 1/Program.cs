using System;
using System.Collections;

namespace HotelAppZadanie
{
    //Модельный класс
    public class HotelRoom
    {
        public int RoomNumber { get; set; }
        public string GuestName { get; set; }

        public HotelRoom(int roomNumber, string guestName)
        {
            RoomNumber = roomNumber;
            GuestName = guestName;
        }

        public override string ToString()
        {
            return $"Номер: {RoomNumber}, Гость: {GuestName}";
        }
    }

    //Класс-менеджер
    public class HotelReservationSystem
    {
        private Hashtable _rooms = new Hashtable();
        
        public void AddReservation(int roomNumber, string guestName)
        {
            if (_rooms.ContainsKey(roomNumber))
            {
                Console.WriteLine("Номер уже занят");
                return;
            }

            _rooms.Add(roomNumber, new HotelRoom(roomNumber, guestName));
            Console.WriteLine("Бронирование добавлено");
        }
        
        public void RemoveReservation(int roomNumber)
        {
            if (_rooms.ContainsKey(roomNumber))
            {
                _rooms.Remove(roomNumber);
                Console.WriteLine("Бронирование удалено");
            }
            else
            {
                Console.WriteLine("Номер не найден");
            }
        }
        
        public void FindReservation(int roomNumber)
        {
            if (_rooms.ContainsKey(roomNumber))
            {
                Console.WriteLine(_rooms[roomNumber]);
            }
            else
            {
                Console.WriteLine("Номер не найден");
            }
        }
        
        public void ShowAll()
        {
            Console.WriteLine("Список бронирований:");

            foreach (DictionaryEntry entry in _rooms)
            {
                Console.WriteLine(entry.Value);
            }
        }

        //Фильтрация по имени
        public void FilterByGuest(string guestName)
        {
            Console.WriteLine($"Поиск по имени: {guestName}");

            foreach (DictionaryEntry entry in _rooms)
            {
                HotelRoom room = (HotelRoom)entry.Value;

                if (room.GuestName.Equals(guestName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(room);
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            HotelReservationSystem system = new HotelReservationSystem();
            
            system.AddReservation(101, "Руслан");
            system.AddReservation(102, "Алан");
            system.AddReservation(103, "Эндрю");
            
            system.ShowAll();

            Console.WriteLine();
            
            system.FilterByGuest("Эндрю");

            Console.WriteLine();
            
            system.RemoveReservation(101);

            Console.WriteLine();

            system.ShowAll();
        }
    }
}