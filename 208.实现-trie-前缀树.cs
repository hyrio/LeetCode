/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

// @lc code=start
public class Trie
{
    public class TrieNode
    {
        public TrieNode()
        {
            Value = 0;
            ChildNodeMap = new Dictionary<char, TrieNode>();
        }

        public int Value;
        public Dictionary<char, TrieNode> ChildNodeMap;
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
            if (i == word.Length - 1)
            {
                node.Value = 1;
            }
        }
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        TrieNode node = _root;
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

            if (i != word.Length - 1)
            {
                node = childNode;
            }
            else
            {
                return childNode.Value == 1;
            }
        }

        return false;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
        TrieNode node = _root;
        for (int i = 0; i < prefix.Length; i++)
        {
            var childNodeMap = node.ChildNodeMap;
            if (childNodeMap == null)
            {
                return false;
            }

            char c = prefix[i];

            TrieNode childNode;
            if (!childNodeMap.TryGetValue(c, out childNode))
            {
                return false;
            }

            if (i == prefix.Length - 1)
            {
                return true;
            }
            else
            {
                node = childNode;
            }
        }

        return false;
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

