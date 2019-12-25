/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-postorder-traversal/description/
 *
 * algorithms
 * Hard (69.22%)
 * Likes:    198
 * Dislikes: 0
 * Total Accepted:    42.8K
 * Total Submissions: 61.8K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的 后序 遍历。
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
 * 输出: [3,2,1]
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
public class Solution 
{
    private List<int> _values = new List<int>();

    public IList<int> PostorderTraversal(TreeNode root) 
    {
        PostOrder(root);
        return _values;
    }

    // 后续遍历: 左子树 --> 右子树 --> 根节点

    // 递归
    public void PostOrder(TreeNode node)
    {
        if (node == null) {
            return;
        }
    
        PostOrder(node.left);
        PostOrder(node.right);
        _values.Add(node.val);
    }
}
// @lc code=end

