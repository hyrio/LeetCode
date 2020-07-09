/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 *
 * https://leetcode-cn.com/problems/permutations/description/
 *
 * algorithms
 * Medium (76.20%)
 * Likes:    781
 * Dislikes: 0
 * Total Accepted:    149.8K
 * Total Submissions: 196.3K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个 没有重复 数字的序列，返回其所有可能的全排列。
 * 
 * 示例:
 * 
 * 输入: [1,2,3]
 * 输出:
 * [
 * ⁠ [1,2,3],
 * ⁠ [1,3,2],
 * ⁠ [2,1,3],
 * ⁠ [2,3,1],
 * ⁠ [3,1,2],
 * ⁠ [3,2,1]
 * ]
 * 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    private List<IList<int>> _results = new List<IList<int>>();

    public IList<IList<int>> Permute(int[] nums)
    {
        List<int> visitePathList = new List<int>();
        Backtrack(nums, visitePathList);
        return _results;
    }

    private void Backtrack(int[] nums, List<int> visitePathList)
    {
        if (visitePathList.Count == nums.Length)
        {
            _results.Add(new List<int>(visitePathList));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int number = nums[i];
            if (visitePathList.Contains(number))
            {
                continue;
            }

            visitePathList.Add(number);
            Backtrack(nums, visitePathList);
            visitePathList.RemoveAt(visitePathList.Count - 1);
        }
    }
}
// @lc code=end

