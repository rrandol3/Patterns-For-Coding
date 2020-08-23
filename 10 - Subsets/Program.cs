using System;
using System.Collections.Generic;

namespace _10___Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3 };
            var test = Permute(nums);
        }

        //Subsets (easy) https://leetcode.com/problems/subsets/
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> subsets = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return subsets;
            }
            subsets.Add(new List<int>());
            foreach (var currNum in nums)
            {
                int n = subsets.Count;
                for (int i = 0; i < n; i++)
                {
                    var set = new List<int>(subsets[i]);
                    set.Add(currNum);
                    subsets.Add(set);
                }
            }

            return subsets;
        }

        //Subsets With Duplicates (easy) https://leetcode.com/problems/subsets-ii/
        //Notes: Need to review solution, did not get right
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> subsets = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return subsets;
            }
            int startIndex = 0;
            int endIndex = 0;
            subsets.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    startIndex = endIndex + 1; 
                }
                endIndex = subsets.Count - 1;
                for (int j = startIndex; j <= endIndex; j++)
                {
                    var set = new List<int>(subsets[j]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }
            }
            return subsets;
        }

        //Permutations (medium) https://leetcode.com/problems/permutations/
        //Notes: need to review solution, did not get right
        public static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            Queue<List<int>> permutations = new Queue<List<int>>();
            permutations.Enqueue(new List<int>());
            foreach (var currNum in nums)
            {
                int n = permutations.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> oldPermutation = permutations.Dequeue();
                    for (int j = 0; j <= oldPermutation.Count; j++)
                    {
                        List<int> newPermutation = new List<int>(oldPermutation);
                        newPermutation.Insert(j, currNum);
                        if (newPermutation.Count == nums.Length)
                        {
                            results.Add(newPermutation);
                        }
                        else
                        {
                            permutations.Enqueue(newPermutation);
                        }
                    }
                }
            }
            return results;
        }
    }
}
