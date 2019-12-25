/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
 *
 * https://leetcode-cn.com/problems/symmetric-tree/description/
 *
 * algorithms
 * Easy (49.25%)
 * Likes:    545
 * Dislikes: 0
 * Total Accepted:    79.1K
 * Total Submissions: 160.6K
 * Testcase Example:  '[1,2,2,3,4,4,3]'
 *
 * 给定一个二叉树，检查它是否是镜像对称的。
 * 
 * 例如，二叉树 [1,2,2,3,4,4,3] 是对称的。
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠/ \ / \
 * 3  4 4  3
 * 
 * 
 * 但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠  \   \
 * ⁠  3    3
 * 
 * 
 * 说明:
 * 
 * 如果你可以运用递归和迭代两种方法解决这个问题，会很加分。
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

using System.Collections.Generic;

public class Solution 
{
    public bool IsSymmetric(TreeNode root) 
    {
        return IsBanlance(root, root);
    }

    // 这道题主要的思路就是 2棵树同时遍历...
    // 递归法
    public bool IsBanlance(TreeNode treeNode1, TreeNode treeNode2)
    {
        if (treeNode1 == null && treeNode2 == null) {
            return true;
        }

        if (treeNode1 == null || treeNode2 == null) {
            return false;
        }

        if (treeNode1.val != treeNode2.val) {
            return false;
        }

        return IsBanlance(treeNode1.left, treeNode2.right) && IsBanlance(treeNode1.right, treeNode2.left);
    }

    // 遍历法
    // 因为要判断2棵树镜像一样，所以需要同时遍历2棵树。
    // 只要左树同级的左节点等于右树的右节点，同级的右节点等于左节点就是镜像树
    public bool DoubleBFS(TreeNode node)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            var treeNode1 = queue.Dequeue();    
            var treeNode2 = queue.Dequeue();
            if (treeNode1 == null && treeNode2 == null) {
                continue;
            }

            if (treeNode1 == null || treeNode2 == null) {
                return false;
            }

            if (treeNode1.val != treeNode2.val) {
                return false;
            }

            queue.Enqueue(treeNode1.left);
            queue.Enqueue(treeNode2.right);
            queue.Enqueue(treeNode1.right);
            queue.Enqueue(treeNode2.left);
        }

        return true;
    }
}
// @lc code=end

