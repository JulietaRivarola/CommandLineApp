using System;
namespace CommandLineApp.ConsoleApp;
class Program
{
  static void Main(string[] args)
  {
    var commandProcessor = new CommandProcessor();

    while (true)
    {
      Console.Write("> ");
      var commandLine = Console.ReadLine();

      if (commandLine is null)
      {
        Console.WriteLine("Invalid command");
        return;
      }

      if (commandLine == "exit")
      {
        break;
      }

      var commandParts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      if (commandParts.Length == 0)
      {
        Console.WriteLine("Invalid command");
        continue;
      }

      var commandName = commandParts[0];
      var commandArgs = commandParts.Skip(1).ToArray();

      commandProcessor.ProcessCommand(commandName, commandArgs);
    }
  }
}