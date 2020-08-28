using System;
using System.Collections.Generic;

namespace _30___Facebook
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1,2,3 };
            var test = SubarraySum(nums, 3);
        }

        //680. Valid Palindrome II https://leetcode.com/problems/valid-palindrome-ii/
        //input: abca -> acba
        //Notes: did not get right
        public static bool ValidPalindrome(string s)
        {
            int low = 0;
            int high = s.Length - 1;
            int count = 1;
            int idx = -1;
            while (low <= high)
            {
                if (s[low] == s[high])
                {
                    low++;
                    high--;
                }
                else
                {
                    if (count == 0)
                    {
                        return false;
                    }
                    if (s[low] == s[idx])
                    {
                        low++;
                    }
                    else
                    {
                        idx = high;
                        high--;
                        low++;
                        count--;
                    }
                }
            }
            return true;
        }

        //560. Subarray Sum Equals K https://leetcode.com/problems/subarray-sum-equals-k/
        public static int SubarraySum(int[] nums, int k)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            else if (nums.Length == 1)
            {
                if (nums[0] == k)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            int count = 0;
            int start = 0;
            int sum = 0;
            for (int end = 0; end < nums.Length; end++)
            {
                sum += nums[end];
                while (sum >= k)
                {
                    if (sum == k)
                    {
                        count++;
                    }
                    sum -= nums[start];
                    start++;
                }
            }
            return count;
        }
    }
}
