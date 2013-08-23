using System;
using System.IO;
using System.Security;

/* Write a program that enters file name along with its full 
 * file path (e.g. C:\WINDOWS\win.ini), reads its contents and 
 * prints it on the console. Find in MSDN how to use 
 * System.IO.File.ReadAllText(…). Be sure to catch all possible 
 * exceptions and print user-friendly error messages. */

class ReadAndPrintFile
{
    static void Main()
    {
        Console.WriteLine("To read file and print it in the console, enter file path.");
        Console.WriteLine(@"Example: C:\WINDOWS\system.ini");
        try
        {
            ReadAndPrintFiles();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path is Null\n");
            Main();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters.\n");
            Main();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.\n");
            Main();
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid (for example, it is on an unmapped drive).\n");
            Main();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file specified in path was not found.\n");
            Main();
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file.\n");
            Main();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Path specified a file that is read-only -or- This operation is not supported on the current platform -or- Path specified a directory -or- The caller does not have the required permission.\n");
            Main();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in an invalid format.\n");
            Main();
        }
        catch (SecurityException)
        {
            Console.WriteLine("The caller does not have the required permission.\n");
            Main();
        }
    }

    private static void ReadAndPrintFiles()
    {
        // Enter the path
        Console.Write("\n=> ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string enteredPath = Console.ReadLine();
        Console.ResetColor();
        
        // Read the file
        string outputContent = File.ReadAllText(enteredPath);

        // Print the file
        Console.WriteLine(outputContent);
    }
}