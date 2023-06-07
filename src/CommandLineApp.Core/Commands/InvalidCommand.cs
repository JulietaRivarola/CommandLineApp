namespace CommandLineApp.Core.Commands;
public class InvalidCommand : ICommand
{
  public string Name => "invalid";
  public string Description => "Invalid command.";

  public void Execute(string[] args) {
    Console.WriteLine("Invalid command. Use the 'help' command to see the list of available commands.");
  }
}
