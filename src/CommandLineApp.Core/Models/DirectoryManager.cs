using System;
using System.IO;

namespace CommandLineApp.Core.Models;

public class DirectoryManager
{
  private string currentDirectory;

  public DirectoryManager()
  {
    currentDirectory = Directory.GetCurrentDirectory();
  }

  public string GetCurrentDirectory()
  {
    return currentDirectory;
  }

  public bool ChangeDirectory(string targetPath)
  {
    string newPath = Path.GetFullPath(targetPath);

    if (Directory.Exists(newPath))
    {
      currentDirectory = newPath;
      return true;
    }

    return false;
  }
}

