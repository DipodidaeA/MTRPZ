using System.Text;
using System.IO;
using System;
using System.Threading;
class Run
{
    static void Main()
    {
        string pathRead = "";
        string pathWrite = "";
        string pathFile = "";
        string textFile = "";
        bool work = true;
        bool havePathRead;
        while (work)
        {
            ConsoleHelp(pathRead, pathWrite);
            switch (Console.ReadLine())
            {
                case "s":
                    Console.Clear();
                    Console.Write("Input path for file that you need read: ");
                    pathRead = Console.ReadLine();
                    break;
                case "c":
                    if (havePathRead)
                    {
                        Console.Clear();
                        Console.Write("Command:\n" + "yes - change text\n" + "no - not change text\n" + "Input command: ");
                        if (Console.ReadLine() == "yes")
                        {
                            string textNewFile = "";
                            textFile = File.ReadAllText(pathRead);
                            textNewFile = textFile;
                            File.WriteAllText(pathWrite, textNewFile);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Text change is cancel");
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error change text. File is missing");
                        Thread.Sleep(2000);
                    }
                    break;
                case "sf":
                    Console.Clear();
                    Console.Write("Input path and name for new file: ");
                    pathWrite = Console.ReadLine();
                    break;
                case "r":
                    Console.Clear();
                    Console.Write("Input path for file that need read: ");
                    pathFile = Console.ReadLine();
                    if (!File.Exists(pathFile))
                    {
                        Console.Clear();
                        Console.WriteLine("Path haven't file\n");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        textFile = File.ReadAllText(pathFile);
                        Console.Clear();
                        Console.WriteLine("{0}\n\n", textFile);
                        Console.Write("Press Enter for finished read: ");
                        Console.ReadLine();
                    }
                    break;
                case "e":
                    work = false;
                    Console.Clear();
                    Console.WriteLine("Working is complete");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Command not found");
                    Thread.Sleep(2000);
                    break;
            }
        }
        void ConsoleHelp(string path, string path2)
        {
            Console.Clear();
            if (!File.Exists(path))
            {
                Console.WriteLine("File information: path haven't file\n");
                havePathRead = false;
            }
            else
            {
                Console.WriteLine("File information: path have file\n");
                havePathRead = true;
            }
            Console.Write("Your path for change file text: {0}\n\n" + "Your path and name for new file: {1}\n\n" + "Command:\n" + "s - set path\n"
                + "sf - set path and name for new file\n" + "c - change text in file\n" + "r - for read file\n" + "e - exit program\n" + "Input command: ", path, path2);
        }
    }
}