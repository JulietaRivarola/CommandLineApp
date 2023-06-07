# CommandLineApp

CommandLineApp is a command-line application that allows you to perform various operations on the file system. You can create files, move files and directories, list files and directories in the current directory, and change directories.

## Usage

The application supports the following commands:

### `tch`

Create a new empty file with the specified name and extension.


tch [file name]


Example:

tch myfile.txt

### `mv`

Rename a file or move a file to a different directory.


mv [source] [destination]

Examples:


mv myfile.txt newfile.txt


mv myfile.txt /path/to/destination/

### `ls`

List the files and directories in the current directory.


ls [-R]


The `-R` modifier shows files and directories recursively in the current directory and its subdirectories.


Examples:


ls


ls -R


### `cd`

Change the current directory.


cd [path]

Example:


cd /path/to/directory/

## Running the Application

To run the application, follow these steps:

1. Build the project using the `dotnet build` command.
2. Navigate to the `CommandLineApp.ConsoleApp` directory.
3. Run the application using the `dotnet run` command.

The application will display a prompt `>`. You can enter valid commands at the prompt to perform operations on the file system.

## System Requirements

- .NET Core SDK 3.1 or higher.

