using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09___Two_Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue pq = new PriorityQueue();
            int[] nums = new int[] { 9, 6, 3, 2, 1 };
            for (int i = 0; i < nums.Length; i++)
            {
                pq.Add(nums[i]);
            }
        }
    }
    public class PriorityQueue
    {
        SortedDictionary<int, List<int>> list;
        public PriorityQueue()
        {
            list = new SortedDictionary<int, List<int>>();
        }
        public void Add(int val)
        {
            if (!list.ContainsKey(val))
            {
                list.Add(val, new List<int>(val));
            }
            else
            {
                list[val].Add(val);
            }
        }
        public int Remove()
        {
            var value = -1;
            if (list[0] != null)
            {
                value = list[0][0];
                list[0].RemoveAt(0);
                if (list[0].Count == 0)
                {
                    list.Remove(0);
                }
            }
            return value;
        }
        public int Peek()
        {
            return list[0][0];
        }
    }
}
