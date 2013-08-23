using System;
using System.Diagnostics;
using System.IO;
using System.Net;

/* Write a program that downloads a file from Internet 
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores 
 * it the current directory. Find in Google how to download 
 * files in C#. Be sure to catch all exceptions and to free 
 * any used resources in the finally block. */

class DownloadAFile
{
    static void Main()
    {
        // Input the file url and detect the file name
        Console.WriteLine("Enter the url of the file.");
        Console.WriteLine(@"Example: http://www.devbg.org/img/Logo-BASD.jpg");
        string pageUrl, fileName;
        GetLinkFindName(out pageUrl, out fileName);

        // Create web client and download the file
        WebClient client = new WebClient();
        try
        {
            client.DownloadFile(pageUrl, fileName);
            Console.WriteLine("Downloading completed!\n");
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid address -or- Empty file -or- The file does not exist.");
            Main();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads.");
            Main();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters.\n");
            Main();
        }
        
        // User options
        Console.WriteLine("Now you have three options:");
        Console.WriteLine("1. Open the file\n2. Open the file directory\n3. Download another file");
        Console.Write("=> ");
        int userInput = int.Parse(Console.ReadLine());
        UserOptions(userInput, fileName);
    }

    // Enter the file url and get the file name
    private static void GetLinkFindName(out string pageUrl, out string fileName)
    {
        pageUrl = Console.ReadLine();
        fileName = Path.GetFileName(pageUrl);
    }

    // Options after downloading
    private static void UserOptions(int userInput, string fileName)
    {
        switch (userInput)
        {
            case 1:
                Process.Start(fileName); // Open the file directly
                break;
            case 2:
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", fileName)); // Open the file directory
                break;
            case 3:
                Main();
                break;
        }
    }
}