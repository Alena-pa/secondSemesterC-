using System;
using System.Linq;
using System.Collections.Generic;

namespace TrieDatatype;

public class Trie
{
    private readonly TrieNode root = new();

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
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        return RemoveRecursively(root, element, 0);
    }

    private bool RemoveRecursively(TrieNode node, string element, int index)
    {
        if (index == element.Length)
        {
            if (!node.isLeaf)
            {
                return false;
            }
            node.isLeaf = false;
            return true;
        }

        char c = element[index];
        int childIndex = c - 'a';
        if (node.children[childIndex] == null)
        {
            return false;
        }

        bool shouldDeleteChild = RemoveRecursively(node.children[childIndex], element, index + 1);

        if (shouldDeleteChild && IsNodeEmpty(node.children[childIndex]))
        {
            node.children[childIndex] = null;
        }

        return shouldDeleteChild;
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
