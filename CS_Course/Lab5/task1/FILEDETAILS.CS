
using System;                // Console
using System.IO;             // FileStream, FileReader
    
class FileDetails 
{

    static void Summarize(char[] contents)
    {
        int vowels = 0, consonants = 0, lines = 0;
        foreach (var el in contents)
        {
            if (el == '\n')
                lines++;
            else if ("AEIOUaeiou".IndexOf(el) != -1)
            {
                vowels++;
            }
            else
            {
                consonants++;
            }
        }
        Console.WriteLine("Total no of characters: {0}", contents.Length);
        Console.WriteLine($"Total no of vowels : {vowels}");
        Console.WriteLine($"Total no of consonants: {consonants}");
        Console.WriteLine($"Total no of lines : {lines}");
    }

    static void Main(string[] args)
    {

        Console.WriteLine(args.Length);
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        string fileName = "";

        if (args.Length > 0)
        {
            fileName = args[0];
            FileStream stream = new FileStream(fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            int size = (int)stream.Length;
            char[] contents = new char[size];
            for (int i = 0; i < size; i++)
            {
                contents[i] = (char)reader.Read();
            }
            /*
            foreach (char ch in contents)
            {
                Console.Write(ch);
            }
            */
            reader.Close();

            Summarize(contents);
        }
        Console.ReadLine();

    }
}
