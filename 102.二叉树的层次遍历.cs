/*
 * @lc app=leetcode.cn id=102 lang=csharp
 *
 * [102] 二叉树的层次遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal/description/
 *
 * algorithms
 * Medium (60.02%)
 * Likes:    339
 * Dislikes: 0
 * Total Accepted:    65.8K
 * Total Submissions: 109.7K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。
 * 
 * 例如:
 * 给定二叉树: [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其层次遍历结果：
 * 
 * [
 * ⁠ [3],
 * ⁠ [9,20],
 * ⁠ [15,7]
 * ]
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
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {        
        Queue<TreeNode> dfsQueue = new Queue<TreeNode>();
        dfsQueue.Enqueue(root);

        while(dfsQueue.Count > 0)
        {
            TreeNode node = dfsQueue.Dequeue();
            if (node.left != null)            
            {

            }

            if (node.right != null)
            {

            }
        }
    }

    public IList<int> CalculateLayerValues(TreeNode leftNode, TreeNode rightNode, IList<IList<int>> values)
    {
        IList<int> temp = new IList<int>();
        if (leftNode != null) {
            temp.Add(leftNode.val);
        }

        if (rightNode != null) {
            temp.Add(rightNode.val);
        }

        values.Add(temp);

        var list1 = CalculateLayerValues(leftNode.left, leftNode.right);
        var list2 = CalculateLayerValues(rightNode.left, rightNode.right);

        return temp;
    }
}
// @lc code=end

