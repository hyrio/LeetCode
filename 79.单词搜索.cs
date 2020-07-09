/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 *
 * https://leetcode-cn.com/problems/word-search/description/
 *
 * algorithms
 * Medium (41.72%)
 * Likes:    458
 * Dislikes: 0
 * Total Accepted:    66.5K
 * Total Submissions: 158.8K
 * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
 *
 * 给定一个二维网格和一个单词，找出该单词是否存在于网格中。
 * 
 * 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
 * 
 * 
 * 
 * 示例:
 * 
 * board =
 * [
 * ⁠ ['A','B','C','E'],
 * ⁠ ['S','F','C','S'],
 * ⁠ ['A','D','E','E']
 * ]
 * 
 * 给定 word = "ABCCED", 返回 true
 * 给定 word = "SEE", 返回 true
 * 给定 word = "ABCB", 返回 false
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * board 和 word 中只包含大写和小写英文字母。
 * 1 <= board.length <= 200
 * 1 <= board[i].length <= 200
 * 1 <= word.length <= 10^3
 * 
 * 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    private HashSet<int> _visited = new HashSet<int>();
    private int[][] _upDownLeftRigth = new int[4][]
    {
        new int[]{-1, 0},
        new int[]{1, 0},
        new int[]{0, -1},
        new int[]{0, 1},
    };

    public bool Exist(char[][] board, string word)
    {
        int row = board.Length;
        int col = board[0].Length;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                _visited.Clear();
                _visited.Add(i * col + j);

                if (BackTrack(i, j, row, col, board, word, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool BackTrack(int row, int col, int maxRow, int maxCol, char[][] board, string word, int wordIndex)
    {
        char c = board[row][col];

        if (word.Length - 1 == wordIndex)
        {
            return word[wordIndex] == c;
        }

        if (word[wordIndex] == c)
        {
            int index = row * maxCol + col;
            _visited.Add(index);

            int newWordLindex = wordIndex + 1;
            for (int i = 0; i < _upDownLeftRigth.Length; i++)
            {
                int newRow = _upDownLeftRigth[i][0] + row;
                int newCol = _upDownLeftRigth[i][1] + col;
                if (!isRowColValid(newRow, newCol, maxRow, maxCol))
                {
                    continue;
                }

                int newIndex = newRow * maxCol + newCol;
                if (_visited.Contains(newIndex))
                {
                    continue;
                }

                if (BackTrack(newRow, newCol, maxRow, maxCol, board, word, newWordLindex))
                {
                    return true;
                }
            }

            _visited.Remove(index);
        }

        return false;
    }

    private bool isRowColValid(int row, int col, int maxRow, int maxCol)
    {
        if (row < 0 || row > maxRow - 1)
        {
            return false;
        }

        if (col < 0 || col > maxCol - 1)
        {
            return false;
        }

        return true;
    }


    // ---------------------------------------------------------
    // 下面这些写法是找出所有的单词组合，然后判断是否存在，效率太差了会超时
    private HashSet<string> _wordSet = new HashSet<string>();

    public bool Exist2(char[][] board, string word)
    {
        int row = board.Length;
        int col = board[0].Length;
        HashSet<int> visited = new HashSet<int>();

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                string tempWord = "";
                visited.Clear();
                BackTrack2(i, j, row, col, board, visited, tempWord);

                if (_wordSet.Contains(word))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void BackTrack2(int row, int col, int maxRow, int maxCol, char[][] board, HashSet<int> visited, string word)
    {
        word = word + board[row][col];
        visited.Add(row * maxCol + col);

        _wordSet.Add(word);

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i == row && j == col)
                {
                    continue;
                }

                if (!isRowColValid2(i, j, row, col, maxRow, maxCol))
                {
                    continue;
                }

                int index = i * maxCol + j;
                if (visited.Contains(index))
                {
                    continue;
                }

                visited.Add(index);
                BackTrack2(i, j, maxRow, maxCol, board, visited, word);
                visited.Remove(index);
            }
        }
    }

    private bool isRowColValid2(int row, int col, int currentRow, int currentCol, int maxRow, int maxCol)
    {
        if (row < 0 || row > maxRow - 1)
        {
            return false;
        }

        if (col < 0 || col > maxCol - 1)
        {
            return false;
        }

        if ((row == currentRow - 1 || row == currentRow + 1) && (col == currentCol - 1 || col == currentCol + 1))
        {
            return false;
        }

        return true;
    }
}
// @lc code=end

