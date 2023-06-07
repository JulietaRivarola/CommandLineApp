using CommandLineApp.Core.Commands;
using CommandLineApp.Core.Models;
namespace CommandLineApp.ConsoleApp;
public class CommandProcessor
{
  private List<ICommand> commands;

  private readonly DirectoryManager directoryManager;

  public CommandProcessor()
  {

    directoryManager = new DirectoryManager();

    commands = new List<ICommand>
      {
        new TchCommand(directoryManager),
        new MoveCommand(directoryManager),
        new ListFilesCommand(directoryManager),
        new ChangeDirectoryCommand(directoryManager),
      };
    commands.Add(CreateHelpCommand());
  }

  public void ProcessCommand(string commandName, string[] args)
  {
    ICommand command = commands.FirstOrDefault(c => c.Name == commandName, new InvalidCommand());
    command.Execute(args);
  }

  private ICommand CreateHelpCommand()
  {
    var helpCommand = new HelpCommand();
    helpCommand.Commands = commands;
    return helpCommand;
  }
}
