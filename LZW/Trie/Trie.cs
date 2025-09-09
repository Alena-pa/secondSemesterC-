using System;
using System.Linq;
using System.Collections.Generic;

namespace TrieDatatype;

public class Trie
{
    private readonly TrieNode root = new();
    public int NumberOfCodes = 0;
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public int code = 0;
        public bool isLeaf = false;
    }


    public bool Add(string element)
    {
        TrieNode curr = root;
        foreach (char symbol in element)
        {
            if (curr.children.ContainsKey(symbol) == false)
            {
                curr.children[symbol] = new TrieNode();
            }
            curr = curr.children[symbol];
        }

        if (curr.isLeaf)
        {
            return false;
        }
        curr.isLeaf = true;
        curr.code = NumberOfCodes;
        NumberOfCodes++;
        return true;
    }

    public bool Contains(string element)
    {
        TrieNode curr = root;
        foreach (char symbol in element)
        {
            if (curr.children.ContainsKey(symbol) == false)
            {
                return false;
            }
            curr = curr.children[symbol];
        }
        return curr.isLeaf;
    }

    public int CodeByPhrase(string element)
    {
        TrieNode curr = root;
        foreach (char symbol in element)
        {
            if (curr.children.ContainsKey(symbol) == false)
            {
                return -1;
            }
            curr = curr.children[symbol];
        }
        return curr.code;
    }

    public string PhraseByCode(int code, Trie trie)
    {
        return DFS(root, code, "");
    }

    public string DFS(TrieNode node, int targetCode, string currPhrase)
    {
        foreach ((char symbol, TrieNode child) in node.children)
        {
            string nextPhrase = currPhrase + symbol;
            if (child == null) continue;

            if (child.isLeaf && child.code == targetCode)
            {
                return nextPhrase;
            }
            else
            {
                string foundPhrase = DFS(child, targetCode, nextPhrase);
                if (foundPhrase != nextPhrase)
                {
                    return foundPhrase;
                }
            }
        }  
        return currPhrase;
    }
    public bool Remove(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        return RemoveRecursively(root, element);
    }

    private bool RemoveRecursively(TrieNode node, string element)
    {
        if (element.Length == 0)
        {
            if (node.isLeaf)
            {
                node.isLeaf = false;
            }
            if (node.children.Count > 0) return true;
            return false;
        }
        bool canRemove = RemoveRecursively(node.children[element[0]], element.Substring(1));
        if (canRemove)
        {
            node.children.Remove(element[0]);
        }
        return false;
    }
    private bool IsNodeEmpty(TrieNode node)
    {
        foreach ((char symbol, TrieNode child) in node.children)
        {
            if (child != null)
            {
                return false;
            }
        }
        return true;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
        {
            return 0;
        }

        TrieNode curr = root;

        foreach (char symbol in prefix)
        {
            if (curr.children[symbol] == null)
            {
                return 0;
            }
            curr = curr.children[symbol];
        }

        return CountWords(curr);
    }

    private int CountWords(TrieNode node)
    {
        if (node == null)
        {
            return 0;
        }

        int count = 0;
        if (node.isLeaf)
        {
            count = 1;
        }

        foreach ((char symbol, TrieNode child) in node.children)
        {
            count += CountWords(child);
        }

        return count;
    }
}
