/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 *
 * https://leetcode-cn.com/problems/subsets/description/
 *
 * algorithms
 * Medium (77.41%)
 * Likes:    638
 * Dislikes: 0
 * Total Accepted:    104K
 * Total Submissions: 134.1K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
 * 
 * 说明：解集不能包含重复的子集。
 * 
 * 示例:
 * 
 * 输入: nums = [1,2,3]
 * 输出:
 * [
 * ⁠ [3],
 * [1],
 * [2],
 * [1,2,3],
 * [1,3],
 * [2,3],
 * [1,2],
 * []
 * ]
 * 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    private List<IList<int>> _results = new List<IList<int>>();
    private List<int> _vistedPathList = new List<int>();

    public IList<IList<int>> Subsets(int[] nums)
    {
        List<int> visitedPathList = new List<int>();
        Backtrack(0, nums, visitedPathList);
        return _results;
    }

    private void Backtrack(int start, int[] nums, List<int> visitedPathList)
    {
        _results.Add(new List<int>(visitedPathList));

        // 这个判断可以不写，交给FOR循环来判断返回
        int numsCount = nums.Length;
        if (start >= numsCount)
        {
            return;
        }

        for (int i = start; i < numsCount; i++)
        {
            int number = nums[i];
            visitedPathList.Add(number);

            // 这边不要写成start,而是i+1
            Backtrack(i + 1, nums, visitedPathList);
            visitedPathList.RemoveAt(visitedPathList.Count - 1);
        }
    }
}
// @lc code=end

