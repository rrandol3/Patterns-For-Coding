using System;

namespace _11___Modified_Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[] { 'c', 'f', 'j' };
            var test = NextGreatestLetter(letters, 'k');
        }

        //33. Search in Rotated Sorted Array  https://leetcode.com/problems/search-in-rotated-sorted-array/
        //Notes: did not get right, need to review the solution
        public static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] >= nums[low])
                {
                    if (target >= nums[low] && target < nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    if (target <= nums[high] && target > nums[mid])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }

        //Next Letter (medium) https://leetcode.com/problems/find-smallest-letter-greater-than-target/
        //Notes: did not get right, need to review
        public static char NextGreatestLetter(char[] letters, char target)
        {
            int low = 0;
            int high = letters.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (letters[mid] == target)
                {
                    if (mid + 1 > letters.Length - 1)
                    {
                        return letters[0];
                    }
                    else
                    {
                        return letters[mid + 1];
                    }
                }
                else if (letters[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return letters[low];
        }

        //Number Range (medium) https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        //Notes: did not get right, need to review
        public int[] SearchRange(int[] nums, int target)
        {
            int lowIdx = 0;
            int highIdx = 0;
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    lowIdx = mid;
                    highIdx = mid;
                }
                if (true)
                {

                }
            }
            return new int[] { -1, -1 };
        }
    }
}
