/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
 *
 * https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/description/
 *
 * algorithms
 * Easy (71.92%)
 * Likes:    432
 * Dislikes: 0
 * Total Accepted:    114.1K
 * Total Submissions: 158.6K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，找出其最大深度。
 * 
 * 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
 * 
 * 说明: 叶子节点是指没有子节点的节点。
 * 
 * 示例：
 * 给定二叉树 [3,9,20,null,null,15,7]，
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 返回它的最大深度 3 。
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
    public int MaxDepth(TreeNode root) 
    {
        return MathDepthWithRecursiveSolution(root);
    }

    // 递归解法，参考题目[111]二叉树的最小深度, 111题目会了，这个也会了
    public int MathDepthWithRecursiveSolution(TreeNode node)
    {
        if (node == null) {
            return 0;
        }

        var leftNode = node.left;
        var rightNode = node.right;
        int leftMaxDepth = MaxDepth(leftNode);
        int rightMaxDepth = MaxDepth(rightNode);
        if (leftNode == null || rightNode == null) {
            return leftMaxDepth + rightMaxDepth + 1;
        }
        else
        {
            return Math.Max(leftMaxDepth, rightMaxDepth) + 1;
        }
    }
}
// @lc code=end

