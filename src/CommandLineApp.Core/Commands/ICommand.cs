using CommandLineApp.Core.Commands;
namespace CommandLineApp.Core.Commands;

public interface ICommand {
  string Name { get; }
  string Description { get; }
  void Execute(string[] args);
}
