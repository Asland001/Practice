using System;

namespace DistanceZadanie
{
    class Program
    {
        static void Main()
        {
            int D1 = 150, D2 = 725, D3 = 1200, D4 = 3245, D5 = 33360;

            int H, M;

            Process(D1, out H, out M);
            Console.WriteLine($"D1: {D1} км = {H} ч {M} мин");

            Process(D2, out H, out M);
            Console.WriteLine($"D2: {D2} км = {H} ч {M} мин");

            Process(D3, out H, out M);
            Console.WriteLine($"D3: {D3} км = {H} ч {M} мин");

            Process(D4, out H, out M);
            Console.WriteLine($"D4: {D4} км = {H} ч {M} мин");

            Process(D5, out H, out M);
            Console.WriteLine($"D5: {D5} км = {H} ч {M} мин");

            Console.ReadKey();
        }
        
        static void Process(int KM, out int H, out int M)
        {
            H = KM / 60;
            M = KM % 60;
        }
    }
}