/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-preorder-traversal/description/
 *
 * algorithms
 * Medium (63.06%)
 * Likes:    185
 * Dislikes: 0
 * Total Accepted:    57.2K
 * Total Submissions: 90.7K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的 前序 遍历。
 * 
 * 示例:
 * 
 * 输入: [1,null,2,3]  
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  3 
 * 
 * 输出: [1,2,3]
 * 
 * 
 * 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
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
    private List<int> _values = new List<int>();

    public IList<int> PreorderTraversal(TreeNode root) 
    {
        PreOrder(root);
        return _values;
    }

    // 先序遍历：根节点-->左子树--->右子树
    
    // 递归
    public void PreOrder(TreeNode node)
    {
        if (node == null) {
            return;
        }

        _values.Add(node.val);
        PreOrder(node.left);
        PreOrder(node.right);
    }
}
// @lc code=end

