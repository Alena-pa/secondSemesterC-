using System;
using LZW;
using TrieDatatype;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter file path you want to compress or decompress");
            string filePath = Console.ReadLine();
            Console.WriteLine("If you want to compress file enter '-c' otherwise enter '-u'");
            string mode = Console.ReadLine();

            if (mode == "-c")
            {
                var ratio = LZWAlgorythm.CompressFile(filePath);
                Console.WriteLine($"Compression ratio: {ratio}");
            }
            else if (mode == "-u")
            {
                LZWAlgorythm.DecompressFile(filePath);
                Console.WriteLine("Decompression complete.");
            }
            else
            {
                Console.WriteLine("Invalid mode. Use -c to compress or -u to decompress");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
