/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 *
 * https://leetcode-cn.com/problems/plus-one/description/
 *
 * algorithms
 * Easy (41.25%)
 * Likes:    357
 * Dislikes: 0
 * Total Accepted:    83.9K
 * Total Submissions: 203.3K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
 * 
 * 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
 * 
 * 你可以假设除了整数 0 之外，这个整数不会以零开头。
 * 
 * 示例 1:
 * 
 * 输入: [1,2,3]
 * 输出: [1,2,4]
 * 解释: 输入数组表示数字 123。
 * 
 * 
 * 示例 2:
 * 
 * 输入: [4,3,2,1]
 * 输出: [4,3,2,2]
 * 解释: 输入数组表示数字 4321。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[] PlusOne(int[] digits) 
    {
        int digitLength = digits.Length;
        bool expand = false;
        for (int i = digitLength - 1; i >= 0; i--) 
        {
            int digitPlusOneValue = digits[i] + 1;
            if (digitPlusOneValue == 10)  
            {
                digits[i] = 0;
                if (i == 0) {
                    expand = true;
                }
            }
            else
            {
                digits[i] = digitPlusOneValue;
                break;
            }
        }

        if (expand)
        {
            int[] newDigits = new int[digitLength + 1];
            newDigits[0] = 1;
            for (int i = 0; i < digitLength; i++) {
                newDigits[i + 1] = digits[i];
            }

            return newDigits;
        }
        else {
            return digits;
        }
    }
}
// @lc code=end

