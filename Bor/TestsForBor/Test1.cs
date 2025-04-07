using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrieDatatype;

namespace TrieTests
{
    [TestClass]
    public class TrieTests
    {
        private Trie trie;

        [TestInitialize]
        public void Setup()
        {
            trie = new Trie();
        }

        [TestMethod]
        public void AddWordTrue()
        {
            Assert.IsTrue(trie.Add("hello"));
            Assert.IsTrue(trie.Add("world"));
        }

        [TestMethod]
        public void AddDuplicateWord()
        {
            trie.Add("hello");
            Assert.IsFalse(trie.Add("hello"));
        }

        [TestMethod]
        public void ContainWordTrue()
        {
            trie.Add("test");
            Assert.IsTrue(trie.Contains("test"));
        }

        [TestMethod]
        public void ContainsWordFalse()
        {
            Assert.IsFalse(trie.Contains("missing"));
        }

        [TestMethod]
        public void RemoveWordTrue()
        {
            trie.Add("apple");
            trie.Add("application");
            trie.Add("app");
            Assert.IsFalse(trie.Remove("apple"));
            Assert.IsFalse(trie.Contains("apple"));
        }

        [TestMethod]
        public void RemoveWordFalse()
        {
            Assert.IsFalse(trie.Remove("world"));
        }

        [TestMethod]
        public void RemoveBiggerWord()
        {
            trie.Add("hello");
            trie.Add("hell");
            trie.Remove("hello");
            Assert.IsTrue(trie.Contains("hell"));
        }

        [TestMethod]
        public void HowManyStartsWithPrefix()
        {
            trie.Add("apple");
            trie.Add("app");
            trie.Add("ape");
            trie.Add("banana");
            Assert.AreEqual(3, trie.HowManyStartsWithPrefix("ap"));
            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("ba"));
            Assert.AreEqual(0, trie.HowManyStartsWithPrefix("z"));
        }
    }
}
