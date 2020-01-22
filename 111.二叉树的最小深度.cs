/*
 * @lc app=leetcode.cn id=111 lang=csharp
 *
 * [111] 二叉树的最小深度
 *
 * https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/description/
 *
 * algorithms
 * Easy (41.05%)
 * Likes:    195
 * Dislikes: 0
 * Total Accepted:    46.1K
 * Total Submissions: 112.4K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，找出其最小深度。
 * 
 * 最小深度是从根节点到最近叶子节点的最短路径上的节点数量。
 * 
 * 说明: 叶子节点是指没有子节点的节点。
 * 
 * 示例:
 * 
 * 给定二叉树 [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 返回它的最小深度  2.
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
    public int MinDepth(TreeNode root) {
        return Answer(root);
    }

    // 自己写的。。需要传递LAYER, 有点浪费栈空间
    public int Helper(TreeNode node, int layer)
    {
        if (node == null) {
            return layer;
        }

        layer = layer + 1;
        var leftNode = node.left;
        var rightNode = node.right;
        if (leftNode == null && rightNode == null)
        {
            return layer;
        }
        else
        {
            if (leftNode != null && rightNode == null)
            {
                return Helper(leftNode, layer);
            }
            else if (rightNode != null && leftNode == null)
            {
                return Helper(rightNode, layer);
            }
            else
            {
                int leftLayer = Helper(leftNode, layer);
                int rightLayer = Helper(rightNode, layer);
                return Math.Min(leftLayer, rightLayer);
            }
        }
    }

    // leetCode上递归的答案，不需要传递当前层数
    public int Answer(TreeNode node)
    {
        // 这边返回0要理解
        // 递归是把问题拆解成更小的粒度，每个粒度的逻辑都是一样的。然后入栈先进后出的执行.
        // 所以这边只是检测当前node的深度是多少，当前NODE是空那么当然是0
        if (node == null) {
            return 0;
        }

        var leftNode = node.left;
        var rightNode = node.right;
        int leftLayer = Answer(node.left);
        int rightLayer = Answer(node.right);
        if (leftNode == null || rightNode == null)
        {
            // 如果左子节点为NULL且右子节点为NULL，则当前节点的深度为1
            // 如果一个子节点为NULL，另外个子节点非NULL，则以有子节点的深度为准
            return leftLayer + rightLayer + 1;
        }
        else
        {
            return Math.Min(leftLayer, rightLayer) + 1;
        }
    }
}
// @lc code=end

