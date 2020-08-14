using System;
using System.Collections.Generic;
using System.Reflection;

namespace _02___Two_Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "reg";
            var chars1 = str1.ToCharArray();
            char[] chars = new char[3];
            chars[0] = 'r';
            chars[1] = 'e';
            chars[2] = 'g';
            string test = new string(chars);
            Console.WriteLine(test);
        }

        //Pair with Target Sum (easy)
        //Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target.
        //Input: [1, 2, 3, 4, 6], target=6
        //Output: [1, 3]
        //Explanation: The numbers at index 1 and 3 add up to 6: 2+4=6
        //Altenate Approach: use dictionary to store nums and look for differences
        public static int[] Search(int[] arr, int targetSum)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low < high)
            {
                int currSum = arr[low] + arr[high];
                if (currSum == targetSum)
                {
                    return new int[] { low, high };
                }
                else if (currSum > targetSum)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }
            return new int[] { -1, -1 };
        }

        //Remove Duplicates (easy)
        //Given an array of sorted numbers, remove all duplicates from it. You should not use any extra space; after removing the duplicates in-place return the new length of the array.
        //Input: [2, 3, 3, 3, 6, 9, 9]
        //Output: 4
        //Explanation: The first four elements after removing the duplicates will be[2, 3, 6, 9].
        public static int Remove(int[] arr)
        {
            int nextNonDuplicate = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[nextNonDuplicate - 1] != arr[i])
                {
                    arr[nextNonDuplicate] = arr[i];
                    nextNonDuplicate++;
                }
            }
            return nextNonDuplicate;
        }

        //Similar Question
        // Given an unsorted array of numbers and a target ‘key’, remove all instances of ‘key’ in-place and return the new length of the array.
        //Notes: still confused about solution
        //Input: [2, 11, 2, 2, 1], Key=2
        //Output: 2
        //Explanation: The first two elements after removing every 'Key' will be[11, 1].
        public static int Remove2(int[] arr, int key)
        {
            int nextElement = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != key)
                {
                    arr[nextElement] = arr[i];
                    nextElement++;
                }
            }
            return nextElement;
        }

        //Squaring a Sorted Array (easy)
        //Given a sorted array, create a new array containing squares of all the number of the input array in the sorted order.
        //Input: [-2, -1, 0, 2, 3]
        //Output: [0, 1, 4, 4, 9]
        //Notes: trick, use simple two pointer technique but place highest of squares at at end of result array instead of the beginning
        public static int[] MakeSquares(int[] arr)
        {
            int[] squares = new int[arr.Length];
            int low = 0;
            int high = arr.Length - 1;
            int sqrIdx = arr.Length - 1;
            while (low <= high)
            {
                var lowSquared = arr[low] * arr[low];
                var highSquared = arr[high] * arr[high];
                if (lowSquared > highSquared)
                {
                    squares[sqrIdx] = lowSquared;
                    low++;
                }
                else
                {
                    squares[sqrIdx] = highSquared;
                    high--;
                }
                sqrIdx--;
            }
            return squares;
        }

        //Triplet Sum to Zero (medium)
        //Given an array of unsorted numbers, find all unique triplets in it that add up to zero.
        //Input: [-3, 0, 1, 2, -1, 1, -2]
        //Output: [-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]
        //Explanation: There are four unique triplets whose sum is equal to zero.
        //See TripletSumZero class for solution

    }
}
