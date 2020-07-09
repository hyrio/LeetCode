/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

using System.Collections.Generic;

// @lc code=start
public class Trie
{
    public class TrieNode
    {
        private Dictionary<char, TrieNode> _childNodeMap;

        public bool IsWord { get; set; }

        public Dictionary<char, TrieNode> ChildNodeMap { get { return _childNodeMap; } }

        public TrieNode()
        {
            IsWord = false;
            _childNodeMap = new Dictionary<char, TrieNode>();
        }
    }

    private TrieNode _root;

    /** Initialize your data structure here. */
    public Trie()
    {
        _root = new TrieNode();
    }

    /** Inserts a word into the trie. */
    public void Insert(string word)
    {
        TrieNode node = _root;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            var childNodeMap = node.ChildNodeMap;

            TrieNode childNode;
            if (!childNodeMap.TryGetValue(c, out childNode))
            {
                childNode = new TrieNode();
                childNodeMap[c] = childNode;
            }

            node = childNode;
        }

        node.IsWord = true;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        if (FindWordNode(word, out TrieNode node))
        {
            return node.IsWord;
        }
        else
        {
            return false;
        }
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
        return FindWordNode(prefix, out TrieNode node);
    }

    public bool FindWordNode(string word, out TrieNode node)
    {
        node = _root;
        for (int i = 0; i < word.Length; i++)
        {
            var childNodeMap = node.ChildNodeMap;
            if (childNodeMap == null)
            {
                return false;
            }

            char c = word[i];

            TrieNode childNode;
            if (!childNodeMap.TryGetValue(c, out childNode))
            {
                return false;
            }

            node = childNode;
        }

        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

