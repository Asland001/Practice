using CommandApp.Commands;

namespace CommandApp.Invoker
{
    public class PrintManager
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}