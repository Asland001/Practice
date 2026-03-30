using CommandApp.Receiver;

namespace CommandApp.Commands
{
    public class PrintDocumentCommand : ICommand
    {
        private readonly Printer _printer;

        public PrintDocumentCommand(Printer printer)
        {
            _printer = printer;
        }

        public void Execute()
        {
            _printer.Print();
        }
    }
}