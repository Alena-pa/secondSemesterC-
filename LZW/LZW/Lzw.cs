using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TrieDatatype;

namespace LZW;

public class LZWAlgorythm
{
    public static double CompressFile(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);
        var data = sr.ReadLine();

        (string output, string alphabet) = LZWAlgorythm.Compress(data.ToString());

        string outputFilePath = filePath + ".zipped";

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLineAsync(alphabet);
            writer.WriteLineAsync(output);
        }

        double originalSize = new FileInfo(filePath).Length;
        double compressedSize = new FileInfo(outputFilePath).Length - alphabet.Length;
        double ratio = compressedSize / originalSize;

        return ratio;
    }
    public static void DecompressFile(string filePath)
    {
        string outputFilePath = "C:\\Users\\Marina\\Documents\\unzipped.txt";
        
        StreamReader reader = new StreamReader(filePath);
        string alphabet = reader.ReadLine();
        string compressedData = reader.ReadLine();

        string decompressed = Decompress(compressedData, alphabet);
        File.WriteAllText(outputFilePath, decompressed, Encoding.UTF8);
        
    }
    public static (string output, string alphabet) Compress(string text)
    {
        Trie trie = new Trie();
        var alphabet = new List<char>();
        foreach (var i in text)
        {
            trie.Add(i.ToString());
            if (!alphabet.Contains(i))
            {
                alphabet.Add(i);
            }
        }

        var phrase = "";
        var output = "";

        foreach (char symbol in text)
        {   
            if (trie.Contains(phrase + symbol.ToString()))
            {
                phrase = phrase + symbol.ToString();
            }
            else
            {
                trie.Add(phrase + symbol.ToString());
                output += trie.CodeByPhrase(phrase);
                phrase = symbol.ToString();
            }
        }
        output += trie.CodeByPhrase(phrase);
        return (output, string.Join("", alphabet));
    }

    public static string Decompress(string text, string alphabet)
    {
        var baseTrie = new Trie();
        foreach (var i in alphabet)
        {
            baseTrie.Add(i.ToString());
        }
        var previousPhrase = "";
        var output = "";

        foreach (char code in text)
        {
            var code1 = Int32.Parse(code.ToString());
            var currPhrase = baseTrie.PhraseByCode(code1, baseTrie);

            output += currPhrase;

            if (!string.IsNullOrEmpty(previousPhrase))
            {
                string newPhrase = previousPhrase + currPhrase[0];
                baseTrie.Add(newPhrase);
            }
            previousPhrase = currPhrase;
        }
        return output;
    }
}
