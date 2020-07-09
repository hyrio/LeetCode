/*
 * @lc app=leetcode.cn id=211 lang=csharp
 *
 * [211] 添加与搜索单词 - 数据结构设计
 *
 * https://leetcode-cn.com/problems/add-and-search-word-data-structure-design/description/
 *
 * algorithms
 * Medium (44.89%)
 * Likes:    129
 * Dislikes: 0
 * Total Accepted:    11.8K
 * Total Submissions: 26.3K
 * Testcase Example:  '["WordDictionary","addWord","addWord","addWord","search","search","search","search"]\n' +
  '[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]'
 *
 * 设计一个支持以下两种操作的数据结构：
 * 
 * void addWord(word)
 * bool search(word)
 * 
 * 
 * search(word) 可以搜索文字或正则表达式字符串，字符串只包含字母 . 或 a-z 。 . 可以表示任何一个字母。
 * 
 * 示例:
 * 
 * addWord("bad")
 * addWord("dad")
 * addWord("mad")
 * search("pad") -> false
 * search("bad") -> true
 * search(".ad") -> true
 * search("b..") -> true
 * 
 * 
 * 说明:
 * 
 * 你可以假设所有单词都是由小写字母 a-z 组成的。
 * 
 */

using System.Collections.Generic;

// @lc code=start
public class WordDictionary
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
    public WordDictionary()
    {
        _root = new TrieNode();
    }

    /** Adds a word into the data structure. */
    public void AddWord(string word)
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

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word)
    {
        return IsFindWord(word, _root);
    }

    public bool IsFindWord(string word, TrieNode node)
    {
        for (int i = 0; i < word.Length; i++)
        {
            var childNodeMap = node.ChildNodeMap;
            if (childNodeMap == null || childNodeMap.Count <= 0)
            {
                return false;
            }

            char c = word[i];
            if (c == '.')
            {
                foreach (var item in childNodeMap)
                {
                    string subWord = word.Substring(i + 1);
                    if (IsFindWord(subWord, item.Value))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                TrieNode childNode;
                if (!childNodeMap.TryGetValue(c, out childNode))
                {
                    return false;
                }

                node = childNode;
            }
        }

        return node.IsWord;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
// @lc code=end

