using System.IO;
using CommandLineApp.Core.Models;

namespace CommandLineApp.Core.Commands;

public class TchCommand : ICommand
{
  public string Name => "tch";
  public string Description => "Create a new empty file with the specified name and extension.";

  private readonly DirectoryManager directoryManager;

  public TchCommand(DirectoryManager directoryManager)
  {
    this.directoryManager = directoryManager;
  }

  public void Execute(string[] args)
  {
    if (args.Length < 1)
    {
      Console.WriteLine("Invalid command arguments. Usage: tch [file name]");
      return;
    }

    string fileName = args[0];
    string directoryPath = directoryManager.GetCurrentDirectory();
    string filePath = Path.Combine(directoryPath, fileName);

    if (File.Exists(filePath))
    {
      Console.WriteLine($"File '{fileName}' already exists.");
      return;
    }

    try
    {
      using (File.Create(filePath))
      {
        Console.WriteLine($"File '{fileName}' created successfully.");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error creating file '{fileName}': {ex.Message}");
    }
  }

}
