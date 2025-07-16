using System;
using LZW;
using TrieDatatype;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter file path you want to compress or decompress");
        string filePath = Console.ReadLine();
        Console.WriteLine("If you want to compress file enter '-c' otherwise enter '-u'");
        string mode = Console.ReadLine();

        if (mode == "-c")
        {
            var ratio = LZWAlgorythm.CompressFile(filePath);
            Console.WriteLine(ratio);
        }
        else if (mode == "-u")
        {
            LZWAlgorythm.DecompressFile(filePath);
        }
        else
        {
            Console.WriteLine("Invalid mode. Use -c to compress or to -u to decompress");
        }
    }
}