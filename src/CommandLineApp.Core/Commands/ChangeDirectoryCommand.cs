using System;
using System.IO;
using CommandLineApp.Core.Models;

namespace CommandLineApp.Core.Commands;
public class ChangeDirectoryCommand : ICommand
{
  public string Name => "cd";
  public string Description => "Allows navigating between different directories.";

  private readonly DirectoryManager directoryManager;

  public ChangeDirectoryCommand(DirectoryManager directoryManager)
  {
    this.directoryManager = directoryManager;
  }

  public void Execute(string[] args)
  {
    if (args.Length < 1)
    {
      Console.WriteLine("Invalid command arguments. Usage: cd [path]");
      return;
    }

    string targetPath = args[0];

    if (directoryManager.ChangeDirectory(targetPath))
    {
      Console.WriteLine($"Current directory changed to: {directoryManager.GetCurrentDirectory()}");
    }
    else
    {
      Console.WriteLine($"Directory not found: {targetPath}");
    }
  }
}