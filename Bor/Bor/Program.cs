using System;
using TrieDatatype;
class Program
{
    static void Main()
    {
        Trie trie = new Trie();

        trie.Add("apple");
        trie.Add("app");
        trie.Add("application");
        trie.Add("banana");

        Console.WriteLine($"Words starting with 'app': {trie.HowManyStartsWithPrefix("app")}");
        Console.WriteLine($"Contains 'apple': {trie.Contains("apple")}");
        Console.WriteLine($"Contains 'banana': {trie.Contains("banana")}");

        Console.WriteLine($"Removing 'apple': {trie.Remove("apple")}");
        Console.WriteLine($"Contains 'apple' after removal: {trie.Contains("apple")}");
    }
}
