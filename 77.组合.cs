/*
 * @lc app=leetcode.cn id=77 lang=csharp
 *
 * [77] 组合
 *
 * https://leetcode-cn.com/problems/combinations/description/
 *
 * algorithms
 * Medium (73.84%)
 * Likes:    305
 * Dislikes: 0
 * Total Accepted:    59.4K
 * Total Submissions: 80.2K
 * Testcase Example:  '4\n2'
 *
 * 给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
 * 
 * 示例:
 * 
 * 输入: n = 4, k = 2
 * 输出:
 * [
 * ⁠ [2,4],
 * ⁠ [3,4],
 * ⁠ [2,3],
 * ⁠ [1,2],
 * ⁠ [1,3],
 * ⁠ [1,4],
 * ]
 * 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    private List<IList<int>> _results = new List<IList<int>>();

    public IList<IList<int>> Combine(int n, int k)
    {
        List<int> pathList = new List<int>();
        Backtrack(1, n, pathList, 1, k);
        return _results;
    }

    private void Backtrack(int start, int n, List<int> pathList, int depth, int k)
    {
        // 这个树的深度这边没什么作用。判断递归的结束条件可以用过 pathList.Count == k 来决定。
        // if (depth > k)
        // {
        //     _results.Add(new List<int>(pathList));
        //     return;
        // }

        if (pathList.Count == k)
        {
            _results.Add(new List<int>(pathList));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            pathList.Add(i);
            Backtrack(i + 1, n, pathList, depth + 1, k);
            pathList.RemoveAt(pathList.Count - 1);
        }
    }
}
// @lc code=end

