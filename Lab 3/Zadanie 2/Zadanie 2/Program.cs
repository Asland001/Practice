using System;

namespace StaticArrayZadanie
{

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    
    static class ArrayUtils
    {
        public static void ShuffleArray(Person[] people)
        {
            Random rnd = new Random();

            for (int i = people.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                
                Person temp = people[i];
                people[i] = people[j];
                people[j] = temp;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Person[] people =
            {
                new Person("Артём", 18),
                new Person("Иван", 20),
                new Person("Оля", 19),
                new Person("Макс", 21)
            };

            Console.WriteLine("До перемешивания:");
            PrintArray(people);

            ArrayUtils.ShuffleArray(people);

            Console.WriteLine("\nПосле перемешивания:");
            PrintArray(people);

            Console.ReadKey();
        }
        
        static void PrintArray(Person[] people)
        {
            foreach (var p in people)
            {
                Console.WriteLine($"{p.Name}, {p.Age}");
            }
        }
    }
}