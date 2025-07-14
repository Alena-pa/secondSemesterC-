using System;
using LZW;
using TrieDatatype;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text you want to compress");
        string text = Console.ReadLine();
        if (text == null) 
        {
            throw new Exception("Cannot find text");
        }
        var output = LZWAlgorythm.Compress(text);
        Console.WriteLine(output);
    }
}