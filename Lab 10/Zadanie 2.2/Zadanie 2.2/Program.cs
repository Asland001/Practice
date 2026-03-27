using System;

namespace BuilderAppZadanie
{
    //Продукт
    public class Car
    {
        public string Engine { get; set; }
        public string Wheels { get; set; }
        public string Body { get; set; }

        public void Show()
        {
            Console.WriteLine($"Двигатель: {Engine}");
            Console.WriteLine($"Колёса: {Wheels}");
            Console.WriteLine($"Кузов: {Body}");
        }
    }

    //Интерфейс строителя
    public interface ICarBuilder
    {
        void BuildEngine();
        void BuildWheels();
        void BuildBody();
        Car GetCar();
    }

    //Конкретные строители

    public class SedanBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void BuildEngine() => _car.Engine = "1.6L бензин";
        public void BuildWheels() => _car.Wheels = "4 стандартных колеса";
        public void BuildBody() => _car.Body = "Седан";

        public Car GetCar() => _car;
    }

    public class SUVBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void BuildEngine() => _car.Engine = "2.5L дизель";
        public void BuildWheels() => _car.Wheels = "4 внедорожных колеса";
        public void BuildBody() => _car.Body = "SUV";

        public Car GetCar() => _car;
    }

    public class TruckBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void BuildEngine() => _car.Engine = "5.0L дизель";
        public void BuildWheels() => _car.Wheels = "6 грузовых колес";
        public void BuildBody() => _car.Body = "Грузовик";

        public Car GetCar() => _car;
    }

    //Директор
    public class CarDirector
    {
        public Car Construct(ICarBuilder builder)
        {
            builder.BuildEngine();
            builder.BuildWheels();
            builder.BuildBody();

            return builder.GetCar();
        }
    }

    class Program
    {
        static void Main()
        {
            CarDirector director = new CarDirector();

            //Седан
            Car sedan = director.Construct(new SedanBuilder());
            Console.WriteLine("Седан:");
            sedan.Show();

            Console.WriteLine();

            //SUV
            Car suv = director.Construct(new SUVBuilder());
            Console.WriteLine("SUV:");
            suv.Show();

            Console.WriteLine();

            //Грузовик
            Car truck = director.Construct(new TruckBuilder());
            Console.WriteLine("Грузовик:");
            truck.Show();
        }
    }
}