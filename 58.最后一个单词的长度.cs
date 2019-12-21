/*
 * @lc app=leetcode.cn id=58 lang=csharp
 *
 * [58] 最后一个单词的长度
 */

// @lc code=start
public class Solution 
{
    public int LengthOfLastWord(string s) 
    {
        int lastWorldLength = 0;
        int length = s.Length;        
        for (int i = length - 1; i >= 0; i--)
        {
            char temp = s[i];
            if (temp == ' ')
            {
                if (lastWorldLength == 0) {
                    continue;
                }
                else {
                    break;
                }
            }

            lastWorldLength ++;
        }

        return lastWorldLength;
    }
}
// @lc code=end

