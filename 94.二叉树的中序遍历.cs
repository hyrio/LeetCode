/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-inorder-traversal/description/
 *
 * algorithms
 * Medium (69.31%)
 * Likes:    350
 * Dislikes: 0
 * Total Accepted:    87.3K
 * Total Submissions: 125.9K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的中序 遍历。
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
 * 输出: [1,3,2]
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

    public IList<int> InorderTraversal(TreeNode root) 
    {
        StackTraversal2(root);
        return _values;
    }

    // 中序遍历 左子树-->根节点-->右子树
    public void Inorder(TreeNode node)
    {
        if (node == null) {
            return;
        }

        Inorder(node.left);
        _values.Add(node.val);    
        Inorder(node.right);
    }

    public void StackTraversal(TreeNode root)
    {
        if (root == null) {
            return;
        }

        Stack<TreeNode> tempStack = new Stack<TreeNode>();
        tempStack.Push(root);

        HashSet<TreeNode> pushed = new HashSet<TreeNode>();

        while (tempStack.Count > 0)
        {
            TreeNode node = tempStack.Peek();

            if (node.left != null && !pushed.Contains(node.left))
            {
                pushed.Add(node.left);
                tempStack.Push(node.left);
                continue;
            }

            tempStack.Pop();
            _values.Add(node.val);            

            if (node.right != null && !pushed.Contains(node.right)) 
            {
                pushed.Add(node.right);
                tempStack.Push(node.right);
            }
        }
    }

    // 这个遍历算法是看标准答案的。。。
    // 先循环查找一个节点的所有子节点，直到最后一个左子节点。
    // 如果最后一个左子节点再没有左子节点，那么说明它是<<中间的根节点>>
    // 那么直接访问，然后再访问右子节点
    public void StackTraversal2(TreeNode root)
    {
        Stack<TreeNode> tempStack = new Stack<TreeNode>();

        TreeNode currentNode = root;
        while (currentNode != null || tempStack.Count > 0)
        {
            // 找当前所有的子节点
            while (currentNode != null)
            {
                // 当前点入栈
                tempStack.Push(currentNode);
                currentNode = currentNode.left;                
            }

            currentNode = tempStack.Pop();
            _values.Add(currentNode.val);

            // 开始找该节点的右子节点
            currentNode = currentNode.right;
        }
    }
}
// @lc code=end

