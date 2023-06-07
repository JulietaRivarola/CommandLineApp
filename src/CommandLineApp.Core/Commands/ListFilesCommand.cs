using System;
using System.IO;
using CommandLineApp.Core.Models;

namespace CommandLineApp.Core.Commands
{
  public class ListFilesCommand : ICommand
  {
    public string Name => "ls";
    public string Description => "Displays the files and directories in the current directory.";

    private readonly DirectoryManager directoryManager;

    public ListFilesCommand(DirectoryManager directoryManager)
    {
      this.directoryManager = directoryManager;
    }

    public void Execute(string[] args)
    {

      if (args.Length > 0 && args[0] != "-R")
      {
        Console.WriteLine("Invalid command");
        return;
      }

      bool recursive = args.Contains("-R");

      string currentDirectory = directoryManager.GetCurrentDirectory();

      if (recursive)
      {
        ListFilesRecursive(currentDirectory);
      }
      else
      {
        ListFiles(currentDirectory);
      }
    }

    private void ListFiles(string directory)
    {
      string[] files = Directory.GetFiles(directory);
      string[] directories = Directory.GetDirectories(directory);

      Console.WriteLine("Files:");
      foreach (string file in files)
      {
        Console.WriteLine(Path.GetFileName(file));
      }

      Console.WriteLine("Directories:");
      foreach (string subdirectory in directories)
      {
        Console.WriteLine(Path.GetFileName(subdirectory));
      }
    }

    private void ListFilesRecursive(string directory)
    {
      ListFiles(directory);
      string[] subdirectories = Directory.GetDirectories(directory);
      foreach (string subdirectory in subdirectories)
      {
        ListFilesRecursive(subdirectory);
      }
    }
  }
}
