/*
 * @lc app=leetcode.cn id=173 lang=csharp
 *
 * [173] 二叉搜索树迭代器
 *
 * https://leetcode-cn.com/problems/binary-search-tree-iterator/description/
 *
 * algorithms
 * Medium (69.66%)
 * Likes:    108
 * Dislikes: 0
 * Total Accepted:    10.9K
 * Total Submissions: 15.6K
 * Testcase Example:  '["BSTIterator","next","next","hasNext","next","hasNext","next","hasNext","next","hasNext"]\n[[[7,3,15,null,null,9,20]],[null],[null],[null],[null],[null],[null],[null],[null],[null]]'
 *
 * 实现一个二叉搜索树迭代器。你将使用二叉搜索树的根节点初始化迭代器。
 * 
 * 调用 next() 将返回二叉搜索树中的下一个最小的数。
 * 
 * 
 * 
 * 示例：
 * 
 * 
 * 
 * BSTIterator iterator = new BSTIterator(root);
 * iterator.next();    // 返回 3
 * iterator.next();    // 返回 7
 * iterator.hasNext(); // 返回 true
 * iterator.next();    // 返回 9
 * iterator.hasNext(); // 返回 true
 * iterator.next();    // 返回 15
 * iterator.hasNext(); // 返回 true
 * iterator.next();    // 返回 20
 * iterator.hasNext(); // 返回 false
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * next() 和 hasNext() 操作的时间复杂度是 O(1)，并使用 O(h) 内存，其中 h 是树的高度。
 * 你可以假设 next() 调用总是有效的，也就是说，当调用 next() 时，BST 中至少存在一个下一个最小的数。
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
public class BSTIterator 
{
    private int _index;
    private List<int> _inorderTraversal = new List<int>();

    // 关键是中序遍历。二叉搜索树中序遍历的结果就是从小到大排列
    public BSTIterator(TreeNode root) 
    {
        _index = 0;
        InorderTraversal(root);
    }
    
    /** @return the next smallest number */
    public int Next() 
    {
        int value = _inorderTraversal[_index ++];
        return value;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() 
    {
        int count = _index + 1;
        if (_inorderTraversal.Count >= count)
        {
            return true;
        }

        return false;
    }

    private void InorderTraversal(TreeNode node)
    {
        if (node == null) {
            return;
        }
        
        InorderTraversal(node.left);
        _inorderTraversal.Add(node.val);
        InorderTraversal(node.right);
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
// @lc code=end

