using System;
using System.Linq;
using System.Collections.Generic;

namespace TrieDatatype;

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool isLeaf = false;
    }

    public bool Add(string element)
    {
        TrieNode curr = root;
        foreach (char symbol in element)
        {
            int index = symbol - 'a';
            if (curr.children[index] == null)
            {
                curr.children[index] = new TrieNode();
            }
            curr = curr.children[index];
        }

        if (curr.isLeaf)
        {
            return false;
        }
        curr.isLeaf = true;
        return true;
    }

    public bool Contains(string element)
    {
        TrieNode curr = root;
        foreach (char symbol in element)
        {
            int index = symbol - 'a';
            if (curr.children[index] == null)
            {
                return false;
            }
            curr = curr.children[index];
        }
        return curr.isLeaf;
    }

    public bool Remove(string element)
    {
        if (!Contains(element))
        {
            return false;
        }

        return RemoveRecursively(root, element, 0);
        return true;
    }

    private bool RemoveRecursively(TrieNode node, string element, int index)
    {
        Console.WriteLine($"Starting to remove the word: {element}");
        if (index == element.Length)
        {
            if (!node.isLeaf)
            {
                return false;
            }
            node.isLeaf = false;
            return IsNodeEmpty(node);
        }

        char c = element[index];
        int childIndex = c - 'a';
        if (node.children[childIndex] == null)
        {
            return false;
        }

        bool shouldDeleteChild = RemoveRecursively(node.children[childIndex], element, index + 1);

        if (shouldDeleteChild)
        {
            node.children[childIndex] = null;
            return IsNodeEmpty(node) && !node.isLeaf;
        }

        Console.WriteLine($"Child '{c}' to be deleted. Returning false.");
        return false;
    }
    private bool IsNodeEmpty(TrieNode node)
    {
        foreach (TrieNode child in node.children)
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
            int index = symbol - 'a';
            if (curr.children[index] == null)
            {
                return 0;
            }
            curr = curr.children[index];
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

        foreach (TrieNode child in node.children)
        {
            count += CountWords(child);
        }

        return count;
    }
}
