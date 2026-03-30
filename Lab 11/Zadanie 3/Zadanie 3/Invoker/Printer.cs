using System;

namespace CommandApp.Receiver
{
    public class Printer
    {
        public void Print()
        {
            Console.WriteLine("Документ отправлен на печать");
        }

        public void Cancel()
        {
            Console.WriteLine("Печать отменена");
        }
    }
}