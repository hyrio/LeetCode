/*
 * @lc app=leetcode.cn id=114 lang=csharp
 *
 * [114] 二叉树展开为链表
 *
 * https://leetcode-cn.com/problems/flatten-binary-tree-to-linked-list/description/
 *
 * algorithms
 * Medium (66.80%)
 * Likes:    242
 * Dislikes: 0
 * Total Accepted:    23.3K
 * Total Submissions: 34.9K
 * Testcase Example:  '[1,2,5,3,4,null,6]'
 *
 * 给定一个二叉树，原地将它展开为链表。
 * 
 * 例如，给定二叉树
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   5
 * ⁠/ \   \
 * 3   4   6
 * 
 * 将其展开为：
 * 
 * 1
 * ⁠\
 * ⁠ 2
 * ⁠  \
 * ⁠   3
 * ⁠    \
 * ⁠     4
 * ⁠      \
 * ⁠       5
 * ⁠        \
 * ⁠         6
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
    public void Flatten(TreeNode root) 
    {
        InorderTraversal(root);
    }

    // 额，这个先序遍历方法是硬写出来的，结果AC了..
    // 思路就是边递归边从更改NODE节点的右节点，并把左节点设置为NULL
    public TreeNode InorderTraversal(TreeNode node)
    {
        if (node == null) {
            return null;
        }

        var leftNode = node.left;
        var rightNode = node.right;;
        if (leftNode == null && rightNode == null) {
            return node;
        }

        TreeNode lastNode = node;
        if (leftNode != null)
        {
            lastNode.left = null;
            lastNode.right = leftNode;
            lastNode = leftNode;
            
            TreeNode lastLeftNode = InorderTraversal(leftNode);
            if (lastLeftNode != null) {
                lastNode = lastLeftNode;
            }
        }

        if (rightNode != null)
        {
            lastNode.left = null;
            lastNode.right = rightNode;
            lastNode = rightNode;

            TreeNode lastRightNode = InorderTraversal(rightNode);
            if (lastRightNode != null) {
                lastNode = lastRightNode;
            }
        }

        return lastNode;
    }
}
// @lc code=end

