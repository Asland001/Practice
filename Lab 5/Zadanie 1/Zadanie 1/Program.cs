using System;

abstract class Worker
{
    public abstract void DoWork();
}

//Класс Сварщик
class Welder : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Сварщик выполняет сварку деталей");
    }
}

//Класс Сборщик
class Assembler : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Сборщик собирает изделия");
    }
}

//Класс Электрик
class Electrician : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Электрик проводит электричество");
    }
}

class Program
{
    static void Main()
    {
        Worker[] workers = new Worker[3];
        
        workers[0] = new Welder();
        workers[1] = new Assembler();
        workers[2] = new Electrician();
        
        foreach (Worker w in workers)
        {
            w.DoWork();
        }
    }
}