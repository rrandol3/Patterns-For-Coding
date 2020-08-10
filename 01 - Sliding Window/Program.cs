using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace _01___Sliding_Window
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aabdec";
            string pattern = "abc";
            Console.WriteLine(FindSubstring(str, pattern));
        }
        //Introduction
        //Given an array, find the average of all contiguous subarrays of size ‘K’ in it.
        public static double[] FindAverages(int K, int[] arr)
        {
            double[] average = new double[arr.Length - K + 1];
            int avgIndex = 0;
            int start = 0;
            double sum = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                sum += arr[end];
                if (end - start + 1 == K)
                {
                    average[avgIndex] = sum / K;
                    sum -= arr[start];
                    start++;
                    avgIndex++;
                }
            }
            return average;
        }

        //Maximum Sum Subarray of Size K (easy)
        //Given an array of positive numbers and a positive number ‘k’, find the maximum sum of any contiguous subarray of size ‘k’.
        public static int FindMaxSubArray(int k, int[] arr)
        {
            int maxSum = 0;
            int currSum = 0;
            int start = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                currSum += arr[end];
                if (end - start + 1 == k)
                {
                    maxSum = Math.Max(maxSum, currSum);
                    currSum -= arr[start];
                    start++;
                }
            }
            return maxSum;
        }

        //Smallest Subarray with a given sum (easy)
        //Given an array of positive numbers and a positive number ‘S’, find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0, if no such subarray exists.
        public static int FindMinSubArray(int S, int[] arr)
        {
            int length = int.MaxValue;
            int start = 0;
            int sum = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                sum += arr[end];
                while (sum >= S)
                {
                    length = Math.Min(length, end - start + 1);
                    sum -= arr[start];
                    start++;
                }
            }
            return length == int.MaxValue ? 0 : length;
        }

        //Longest Substring with K Distinct Characters (medium)
        //Given a string, find the length of the longest substring in it with no more than K distinct characters.
        public static int FindLength(string str, int k)
        {
            int length = 0;
            int start = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            for (int end = 0; end < str.Length; end++)
            {
                if (!charFrequencyMap.ContainsKey(str[end]))
                {
                    charFrequencyMap.Add(str[end], 1);
                }
                else
                {
                    charFrequencyMap[str[end]]++;
                }
                while (charFrequencyMap.Count > k)
                {
                    charFrequencyMap[str[start]]--;
                    if (charFrequencyMap[str[start]] == 0)
                    {
                        charFrequencyMap.Remove(str[start]);
                    }
                    start++;
                }
                length = Math.Max(length, end - start + 1);
            }
            return length;
        }

        //Fruits into Baskets (medium)
        //Write a function to return the maximum number of fruits in both the baskets.
        public static int MaxFruits(char[] arr)
        {
            int count = 0;
            int start = 0;
            Dictionary<char, int> charFreqMap = new Dictionary<char, int>();
            for (int end = 0; end < arr.Length; end++)
            {
                if (!charFreqMap.ContainsKey(arr[end]))
                {
                    charFreqMap.Add(arr[end], 1);
                }
                else
                {
                    charFreqMap[arr[end]]++;
                }
                while (charFreqMap.Count > 2)
                {
                    charFreqMap[arr[start]]--;
                    if (charFreqMap[arr[start]] == 0)
                    {
                        charFreqMap.Remove(arr[start]);
                    }
                    start++;
                }
                count = Math.Max(count, end - start + 1);
            }
            return count;
        }

        //No-repeat Substring (hard)
        //Given a string, find the length of the longest substring which has no repeating characters.
        //Input: String="aabccbb"
        //Output: 3 (abc)
        public static int FindLengthNoRepeat(string str)
        {
            int length = 0;
            int start = 0;
            Dictionary<char, int> indexMap = new Dictionary<char, int>();
            for (int end = 0; end < str.Length; end++)
            {
                if (!indexMap.ContainsKey(str[end]))
                {
                    indexMap.Add(str[end], end);
                }
                else
                {
                    start = Math.Max(start, indexMap[str[end]] + 1);//update starting differently
                }
                indexMap[str[end]] = end;
                length = Math.Max(length, end - start + 1);
            }
            return length;
        }

        //Longest Substring with Same Letters after Replacement (hard)
        //Given a string with lowercase letters only, if you are allowed to replace no more than ‘k’ letters with any letter, find the length of the longest substring having the same letters after replacement.
        //Input: String="aabccbb", k=2
        //Output: 5
        //Explanation: Replace the two 'c' with 'b' to have a longest repeating substring "bbbbb".
        public static int FindLengthKReplacement(string str, int k)
        {
            int length = 0;
            int maxRepeatLetterCount = 0;
            int start = 0;
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            for (int end = 0; end < str.Length; end++)
            {
                if (!freqMap.ContainsKey(str[end]))
                {
                    freqMap.Add(str[end], 1);
                }
                else
                {
                    freqMap[str[end]]++;
                }
                maxRepeatLetterCount = Math.Max(maxRepeatLetterCount, freqMap[str[end]]);
                while (end - start + 1 - maxRepeatLetterCount > k)
                {
                    freqMap[str[start]]--;
                    start++;
                }
                length = Math.Max(length, end - start + 1);
            }
            return length;
        }

        //Longest Subarray with Ones after Replacement (hard)
        //Given an array containing 0s and 1s, if you are allowed to replace no more than ‘k’ 0s with 1s, find the length of the longest contiguous subarray having all 1s.
        //Input: Array=[0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1], k=2
        //Output: 6
        //Explanation: Replace the '0' at index 5 and 8 to have the longest contiguous subarray of 1s having length 6.
        public static int FindLengthReplacingOnes(int[] arr, int k)
        {
            int length = 0;
            int start = 0;
            int maxOnesCount = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                if (arr[end] == 1)
                {
                    maxOnesCount++;
                }
                while (end - start + 1 - maxOnesCount > k)
                {
                    if (arr[start] == 1)
                    {
                        maxOnesCount--;
                    }
                    start++;
                }
                length = Math.Max(length, end - start + 1);
            }
            return length;
        }

        //Permutation in a String (hard) 
        //Given a string and a pattern, find out if the string contains any permutation of the pattern.
        //Input: String="oidbcaf", Pattern="abc"
        //Output: true
        //Notes: need to review, solution doesn't work
        public static bool FindPermutation(string str, string pattern)
        {
            Dictionary<char, int> patternFreqMap = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!patternFreqMap.ContainsKey(pattern[i]))
                {
                    patternFreqMap.Add(pattern[i], 1);
                }
                else
                {
                    patternFreqMap[pattern[i]]++;
                }
                int start = 0;
                int matched = 0;
                for (int end = 0; end < str.Length; end++)
                {
                    if (patternFreqMap.ContainsKey(str[end]))
                    {
                        patternFreqMap[str[end]]--;
                        if (patternFreqMap[str[end]] == 0)
                        {
                            matched++;
                        }
                    }
                    if (matched == patternFreqMap.Count)
                    {
                        return true;
                    }
                    if (end >= pattern.Length - 1)
                    {
                        if (patternFreqMap.ContainsKey(str[start]))
                        {
                            matched--;
                            patternFreqMap[str[start]]++;
                        }
                        start++;
                    }
                }
            }

            return false;
        }

        //String Anagrams (hard)
        //Given a string and a pattern, find all anagrams of the pattern in the given string.
        //Input: String="ppqp", Pattern="pq"
        //Output: [1, 2]
        //Notes: need to review, similar to the questions above need understand the solution, solution is not right
        public static List<int> StringAnagrams(string str, string pattern)
        {
            List<int> results = new List<int>();
            Dictionary<char, int> patternFreqMap = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!patternFreqMap.ContainsKey(pattern[i]))
                {
                    patternFreqMap.Add(pattern[i], 1);
                }
                else
                {
                    patternFreqMap[pattern[i]]++;
                }
            }
            int start = 0;
            int j = 0;
            for (int end = 0; end < str.Length; end++)
            {
                if (patternFreqMap.ContainsKey(str[end]))
                {
                    patternFreqMap[str[start]]--;
                    if (patternFreqMap[str[start]] == 0)
                    {
                        patternFreqMap.Remove(str[start]);
                    }
                    start++;
                }
                else
                {
                    patternFreqMap[str[start]]++;
                }
                if (patternFreqMap.Count == 0)
                {
                    j = end;
                    break;
                }
            }
            while (start <= j)
            {
                results.Add(str[start]);
                start++;
            }
            return results;
        }

        //Smallest Window containing Substring (hard)
        //Given a string and a pattern, find the smallest substring in the given string which has all the characters of the given pattern.
        //Input: String="aabdec", Pattern="abc"
        //Output: "abdec"
        //Notes: need to review, similar to the questions above need understand the solution, solution is not right
        public static string FindSubstring(string str, string pattern)
        {
            Dictionary<char, int> patternFreqMap = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!patternFreqMap.ContainsKey(pattern[i]))
                {
                    patternFreqMap.Add(pattern[i], 1);
                }
                else
                {
                    patternFreqMap[pattern[i]]++;
                }
            }

            int start = 0;
            int stop = 0;
            for (int end = 0; end < str.Length; end++)
            {
                if (patternFreqMap.ContainsKey(str[end]))
                {
                    start = end;
                    while (patternFreqMap.ContainsKey(str[start]) && end < str.Length)
                    {
                        patternFreqMap[str[start]]--;
                        stop++;
                        end++;
                    }
                }
                else
                {
                    start++;
                }
            }

            string ans = string.Empty;
            for (int i = start; i < stop; i++)
            {
                ans += str[i];
            }
            
            return ans;
        }

        //Words Concatenation (hard)
        //Given a string and a list of words, find all the starting indices of substrings in the given string that are a concatenation of all the given words exactly once without any overlapping of words. It is given that all words are of the same length.
        //Input: String="catfoxcat", Words=["cat", "fox"]
        //Output: [0, 3]
        //Explanation: The two substring containing both the words are "catfox" & "foxcat".
        //Notes: need to review, similar to the questions above need understand the solution, solution is not right
        public static List<int> FindWordConcatenation(string str, string[] words)
        {
            List<int> resultIndices = new List<int>();

            return resultIndices;
        }
    }
}
