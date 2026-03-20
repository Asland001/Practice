using System;

class Program
{
    static void Main(string[] args)
    {
        double A = 1.5;
        double B = 6.7;
        double C = 3.2;
        double D = 6.9;

        Console.WriteLine("Исходные значения:");
        Console.WriteLine($"A = {A:F1}, B = {B:F1}, C = {C:F1}, D = {D:F1}");
        Console.WriteLine();

        //Меняем A и B
        Swap(ref A, ref B);
        Console.WriteLine("После Swap(A, B):");
        Console.WriteLine($"A = {A:F1}, B = {B:F1}, C = {C:F1}, D = {D:F1}");

        //Меняем C и D
        Swap(ref C, ref D);
        Console.WriteLine("\nПосле Swap(C, D):");
        Console.WriteLine($"A = {A:F1}, B = {B:F1}, C = {C:F1}, D = {D:F1}");

        //Меняем B и C
        Swap(ref B, ref C);
        Console.WriteLine("\nПосле Swap(B, C):");
        Console.WriteLine($"A = {A:F1}, B = {B:F1}, C = {C:F1}, D = {D:F1}");
    }
    
    static void Swap(ref double X, ref double Y)
    {
        double temp = X;
        X = Y;          
        Y = temp;       
    }
}