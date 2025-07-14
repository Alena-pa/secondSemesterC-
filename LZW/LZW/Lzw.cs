using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrieDatatype;

namespace LZW;

public class LZWAlgorythm
{

    public static (string, Trie) Compress(string text)
    {
        Trie trie = new Trie();

        foreach (var i in text)
        {
            trie.Add(i.ToString());
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
                output += trie.PhraseCode(phrase);
                phrase = symbol.ToString();
            }
        }
        output += trie.PhraseCode(phrase);
        return (output, trie);
    }

    public static string Decompress(string text, Trie trie)
    {
        Trie trieWithCodes = new Trie();

        foreach (var i in text)
        {
            trieWithCodes.Add(i.ToString());
        }

        var phrase = "";
        var output = "";

        foreach (char code in text)
        {
            
        }
        output += trie.PhraseCode(phrase);
        return output;
    }
}
