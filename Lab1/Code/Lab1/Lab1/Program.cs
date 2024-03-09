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
        string lastMesseg= "";
        bool work = true;
        bool havePathRead;
        while (work)
        {
            ConsoleHelp(pathRead, pathWrite, lastMesseg);
            lastMesseg = "";
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
                        Console.Write("Confirm change, write yes or no:\n" + "yes - change text\n" + "no - not change text\n\n" + "Input command: ");
                        if (Console.ReadLine() == "yes")
                        {
                            string textNewFile = "";
                            int textSize;
                            bool preOpen = false;
                            bool ttOpen = false;
                            bool bOpen = false;
                            bool iOpen = false;
                            bool textMdError = false;
                            textFile = File.ReadAllText(pathRead);
                            textFile = textFile.Replace(Environment.NewLine, " ");
                            textSize = textFile.Length;
                            textNewFile += "<p>";
                            for (int i = 0; i < textSize; i++)
                            {
                                if (textMdError == false)
                                {
                                    switch (textFile[i])
                                    {
                                        case '`':
                                            if (textFile[i + 1] == '`')
                                            {
                                                if (textFile[i + 2] == '`')
                                                {
                                                    i += 3;
                                                    preOpen = true;
                                                    textNewFile += "\n<pre>\n";
                                                    while (i < textFile.Length)
                                                    {
                                                        if (preOpen == false) { break; }
                                                        else
                                                        {
                                                            switch (textFile[i])
                                                            {
                                                                case '`':
                                                                    if (textFile[i + 1] == '`' && textFile[i + 2] == '`')
                                                                    {
                                                                        preOpen = false;
                                                                        i += 2;
                                                                        textNewFile += "\n</pre>\n";
                                                                    }
                                                                    else
                                                                    {
                                                                        textNewFile += textFile[i];
                                                                        i++;
                                                                    }
                                                                    break;
                                                                default:
                                                                    textNewFile += textFile[i];
                                                                    i++;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                            }
                                            else
                                            {
                                                if (textFile[i + 1] != ' ' && textFile[i + 1] != '*' && textFile[i + 1] != '_')
                                                {
                                                    i++;
                                                    ttOpen = true;
                                                    textNewFile += "\n<tt>\n";
                                                    while (i < textFile.Length)
                                                    {
                                                        if (ttOpen == false) { break; }
                                                        else
                                                        {
                                                            switch (textFile[i])
                                                            {
                                                                case '`':
                                                                    if (textFile[i - 1] != ' ' && textFile[i - 1] != '*' && textFile[i - 1] != '_')
                                                                    {
                                                                        ttOpen = false;
                                                                        textNewFile += "\n</tt>\n";
                                                                    }
                                                                    else
                                                                    {
                                                                        ttOpen = false;
                                                                        textMdError = true;
                                                                    }
                                                                    break;
                                                                default:
                                                                    textNewFile += textFile[i];
                                                                    i++;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                            }
                                            break;
                                        case '*':
                                            if (textFile[i + 1] == '*')
                                            {
                                                if (textFile[i + 2] == '*')
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                                else
                                                {
                                                    if (textFile[i + 2] != ' ' && textFile[i + 2] != '`' && textFile[i + 2] != '_')
                                                    {
                                                        i += 2;
                                                        bOpen = true;
                                                        textNewFile += "\n<b>\n";
                                                        while (i < textFile.Length)
                                                        {
                                                            if (bOpen == false) { break; }
                                                            else
                                                            {
                                                                switch (textFile[i])
                                                                {
                                                                    case '*':
                                                                        if (textFile[i - 1] != ' ' && textFile[i - 1] != '`' && textFile[i - 1] != '_' && textFile[i + 1] == '*')
                                                                        {
                                                                            bOpen = false;
                                                                            textNewFile += "\n</b>\n";
                                                                            i++;
                                                                        }
                                                                        else
                                                                        {
                                                                            bOpen = false;
                                                                            textMdError = true;
                                                                        }
                                                                        break;
                                                                    default:
                                                                        textNewFile += textFile[i];
                                                                        i++;
                                                                        break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        textNewFile += textFile[i];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                textNewFile += textFile[i];
                                            }
                                            break;
                                        case '_':
                                            if (textFile[i + 1] == '_')
                                            {
                                                if (textFile[i + 2] == '_')
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                                else
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                            }
                                            else
                                            {
                                                if (textFile[i + 1] != ' ' && textFile[i + 1] != '*' && textFile[i + 1] != '`' && textFile[i + 1] != '\'')
                                                {
                                                    i++;
                                                    iOpen = true;
                                                    textNewFile += "\n<i>\n";
                                                    while (i < textFile.Length)
                                                    {
                                                        if (iOpen == false) { break; }
                                                        else
                                                        {
                                                            switch (textFile[i])
                                                            {
                                                                case '_':
                                                                    if (textFile[i - 1] != ' ' && textFile[i + 1] != '*' && textFile[i + 1] != '`')
                                                                    {
                                                                        iOpen = false;
                                                                        textNewFile += "\n</i>\n";
                                                                    }
                                                                    else
                                                                    {
                                                                        iOpen = false;
                                                                        textMdError = true;
                                                                    }
                                                                    break;
                                                                default:
                                                                    textNewFile += textFile[i];
                                                                    i++;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    textNewFile += textFile[i];
                                                }
                                            }
                                            break;
                                        case ' ':
                                            if (textFile[i + 1] == ' ')
                                            {
                                                if (textFile[i + 2] == ' ')
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    textNewFile += "\n</p>\n<p>\n";
                                                    i++;
                                                }
                                            }
                                            else
                                            {
                                                textNewFile += textFile[i];
                                            }
                                            break;
                                        default:
                                            textNewFile += textFile[i];
                                            break;
                                    }
                                }
                                else { break; }
                            }
                            if (textMdError != true && preOpen != true && ttOpen != true)
                            {
                                textNewFile += "\n</p>";
                                File.WriteAllText(pathWrite, textNewFile);
                                lastMesseg = "Change complete";
                            }
                            else
                            {
                                lastMesseg = "Error markup in file. Text change is cancel";
                            }
                        }
                        else
                        {
                            lastMesseg = "Text change is cancel";
                        }
                    }
                    else
                    {
                        lastMesseg = "Error change text. File is missing";
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
                        lastMesseg = "Path haven't file\n";
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
                    lastMesseg = "Command not found";
                    break;
            }
        }
        void ConsoleHelp(string path, string path2, string lastMesseg2)
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
                + "sf - set path and name for new file\n" + "c - change text in file\n" + "r - for read file\n" + "e - exit program\n\n" + "Messeg: {2}\n\n" 
                + "Input command: ", path, path2, lastMesseg2);
        }
    }
}