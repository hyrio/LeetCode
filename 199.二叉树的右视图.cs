/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
 *
 * https://leetcode-cn.com/problems/binary-tree-right-side-view/description/
 *
 * algorithms
 * Medium (62.61%)
 * Likes:    127
 * Dislikes: 0
 * Total Accepted:    15.5K
 * Total Submissions: 24.8K
 * Testcase Example:  '[1,2,3,null,5,null,4]'
 *
 * 给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
 * 
 * 示例:
 * 
 * 输入: [1,2,3,null,5,null,4]
 * 输出: [1, 3, 4]
 * 解释:
 * 
 * ⁠  1            <---
 * ⁠/   \
 * 2     3         <---
 * ⁠\     \
 * ⁠ 5     4       <---
 * 
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> RightSideView(TreeNode root) 
    {
        List<int> results = new List<int>();
        RightSideView(root, true, results);
        return results;
    }

    private bool RightSideView(TreeNode node, bool recordeNodeVal, List<int> results)
    {
        if (node == null) {
            return false;
        }

        if (recordeNodeVal)
        {
            results.Add(node.val);
        }        

        var rightNode = node.right;
        if (rightNode != null)
        {
            RightSideView(node.right, true, results);
            return true;
        }

        RightSideView(node.left, true, results);
    }
}
// @lc code=end

