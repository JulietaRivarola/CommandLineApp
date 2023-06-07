using System;
using System.IO;
using CommandLineApp.Core.Models;

namespace CommandLineApp.Core.Commands
{
  public class MoveCommand : ICommand
  {
    public string Name => "mv";
    public string Description => "Changes the name of a file or moves a file to a different directory.";

    private readonly DirectoryManager directoryManager;

    public MoveCommand(DirectoryManager directoryManager)
    {
      this.directoryManager = directoryManager;
    }

    public void Execute(string[] args)
    {
      if (args.Length < 2)
      {
        Console.WriteLine("Two arguments are required: [source] [destination]");
        return;
      }

      string source = args[0];
      string destination = args[1];

      string sourcePath = Path.Combine(directoryManager.GetCurrentDirectory(), source);
      string destinationPath = Path.Combine(directoryManager.GetCurrentDirectory(), destination);

      if (File.Exists(sourcePath))
      {
        if (Directory.Exists(destinationPath))
        {
          destinationPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));
          MoveFile(sourcePath, destinationPath);
        }
        else
        {
          MoveFile(sourcePath, destinationPath);
        }
      }
      else if (Directory.Exists(sourcePath))
      {
        MoveDirectory(sourcePath, destinationPath);
      }
      else
      {
        Console.WriteLine($"The specified source '{source}' does not exist.");
      }
    }


    private void MoveFile(string source, string destination)
    {
      try
      {
        using (var fileStream = File.Open(source, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
          fileStream.Close();
        }

        File.Move(source, destination);

        string sourceFileName = Path.GetFileName(source);
        string destinationFileName = Path.GetFileName(destination);

        Console.WriteLine($"The file '{sourceFileName}' has been renamed to '{destinationFileName}'.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred while renaming the file: {ex.Message}");
      }
    }

    private void MoveDirectory(string source, string destination)
    {
      string destinationPath = Path.Combine(destination, Path.GetFileName(source));

      if (!Directory.Exists(destination))
      {
        Directory.CreateDirectory(destination);
      }

      try
      {
        Directory.Move(source, destinationPath);
        Console.WriteLine($"The directory '{source}' has been moved to '{destinationPath}'.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred while moving the directory: {ex.Message}");
      }
    }

  }
}
