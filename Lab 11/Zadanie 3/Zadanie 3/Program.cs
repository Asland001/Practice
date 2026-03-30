using CommandApp.Commands;
using CommandApp.Invoker;
using CommandApp.Receiver;

namespace CommandAppZadanie
{
    class Program
    {
        static void Main()
        {
            //Получатель
            Printer printer = new Printer();

            //Команды
            ICommand printCommand = new PrintDocumentCommand(printer);
            ICommand cancelCommand = new CancelPrintCommand(printer);

            //Инициатор
            PrintManager manager = new PrintManager();

            //Вызовы
            manager.ExecuteCommand(printCommand);
            manager.ExecuteCommand(cancelCommand);
        }
    }
}