using System;

namespace OrderSystem
{
    abstract class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }

        public Order(int id, string name, double amount)
        {
            OrderId = id;
            CustomerName = name;
            TotalAmount = amount;
        }
        
        public abstract void Display();
    }
    
    sealed class OnlineOrder : Order
    {
        public OnlineOrder(int id, string name, double amount)
            : base(id, name, amount) { }

        public override void Display()
        {
            Console.WriteLine($"[Online] ID:{OrderId}, Клиент:{CustomerName}, Сумма:{TotalAmount}");
        }
    }
    
    sealed class InStoreOrder : Order
    {
        public InStoreOrder(int id, string name, double amount)
            : base(id, name, amount) { }

        public override void Display()
        {
            Console.WriteLine($"[InStore] ID:{OrderId}, Клиент:{CustomerName}, Сумма:{TotalAmount}");
        }
    }

    //Модельный класс
    class Store
    {
        public Order[] Orders { get; set; }

        public Store(Order[] orders)
        {
            Orders = orders;
        }

        //Самый дорогой заказ
        public Order GetLargestOrder()
        {
            Order max = Orders[0];

            foreach (var order in Orders)
            {
                if (order.TotalAmount > max.TotalAmount)
                    max = order;
            }

            return max;
        }

        //Заказы по имени клиента
        public Order[] GetOrdersByCustomer(string customerName)
        {
            Order[] result = new Order[Orders.Length];
            int count = 0;

            foreach (var order in Orders)
            {
                if (order.CustomerName == customerName)
                {
                    result[count++] = order;
                }
            }
            
            Array.Resize(ref result, count);
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Order[] orders =
            {
                new OnlineOrder(1, "Артём", 150),
                new InStoreOrder(2, "Иван", 200),
                new OnlineOrder(3, "Олег", 300),
                new InStoreOrder(4, "Оля", 120)
            };

            Store store = new Store(orders);
            
            Console.WriteLine("Самый дорогой заказ:");
            store.GetLargestOrder().Display();
            
            Console.WriteLine("\nЗаказы Артёма:");
            var list = store.GetOrdersByCustomer("Артём");

            foreach (var order in list)
            {
                order.Display();
            }

            Console.ReadKey();
        }
    }
}