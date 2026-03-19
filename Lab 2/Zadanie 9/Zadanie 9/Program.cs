using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Привет, мир!");
        Console.WriteLine("Исходный StringBuilder: " + sb);
        
        string str = sb.ToString();
        Console.WriteLine("После преобразования в string: " + str);

        //string → StringBuilder
        StringBuilder sbBack = new StringBuilder(str);

        Console.WriteLine("Обратно в StringBuilder: " + sbBack);
        
        sbBack.Append(" Это уже изменённый StringBuilder.");
        Console.WriteLine("После добавления текста: " + sbBack);
    }
}