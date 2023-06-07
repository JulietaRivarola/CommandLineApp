using System;
using System.Collections.Generic;
namespace CommandLineApp.Core.Commands;
public class HelpCommand : ICommand {
  public string Name => "help";
  public string Description => "Displays a list of available commands and their descriptions.";
  public List<ICommand>? Commands { get; set; }

  public void Execute(string[] args) {
    if (Commands == null) {
      Console.WriteLine("No commands available.");
      return;
    }
    
    Console.WriteLine("Available commands:");

    foreach (var command in Commands) {
      Console.WriteLine($"{command.Name}: {command.Description}");
    }
  }
}
