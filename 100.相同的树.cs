/*
 * @lc app=leetcode.cn id=100 lang=csharp
 *
 * [100] 相同的树
 *
 * https://leetcode-cn.com/problems/same-tree/description/
 *
 * algorithms
 * Easy (55.79%)
 * Likes:    276
 * Dislikes: 0
 * Total Accepted:    52.6K
 * Total Submissions: 94.3K
 * Testcase Example:  '[1,2,3]\n[1,2,3]'
 *
 * 给定两个二叉树，编写一个函数来检验它们是否相同。
 * 
 * 如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。
 * 
 * 示例 1:
 * 
 * 输入:       1         1
 * ⁠         / \       / \
 * ⁠        2   3     2   3
 * 
 * ⁠       [1,2,3],   [1,2,3]
 * 
 * 输出: true
 * 
 * 示例 2:
 * 
 * 输入:      1          1
 * ⁠         /           \
 * ⁠        2             2
 * 
 * ⁠       [1,2],     [1,null,2]
 * 
 * 输出: false
 * 
 * 
 * 示例 3:
 * 
 * 输入:       1         1
 * ⁠         / \       / \
 * ⁠        2   1     1   2
 * 
 * ⁠       [1,2,1],   [1,1,2]
 * 
 * 输出: false
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

using System.Collections.Generic;

public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        return IsSameTreeRecursive(p, q);
    }

    public bool IsSameTreeRecursive(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) {
            return true;
        }

        if (p == null || q == null) {
            return false;
        }

        return (p.val == q.val) && IsSameTreeRecursive(p.left, q.left) && IsSameTreeRecursive(p.right, q.right);
    }

    // BFS遍历，同时比较2棵树
    public bool IsSameTreeBFS(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> bfsQueue = new Queue<TreeNode>();
        bfsQueue.Enqueue(p);
        bfsQueue.Enqueue(q);

        while (bfsQueue.Count > 0)
        {
            var node1 = bfsQueue.Dequeue();
            var node2 = bfsQueue.Dequeue();
            if (node1 == null && node2 == null) {
                continue;
            }

            if (node1 == null || node2 == null) {
                return false;
            }

            if (node1.val != node2.val) {
                return false;
            }

            bfsQueue.Enqueue(node1.left);
            bfsQueue.Enqueue(node2.left);
            bfsQueue.Enqueue(node1.right);
            bfsQueue.Enqueue(node2.right);
        }

        return true;
    }

}
// @lc code=end

