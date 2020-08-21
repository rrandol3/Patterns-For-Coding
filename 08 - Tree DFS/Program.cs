using System;
using System.Collections.Generic;

namespace _08___Tree_DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //98. Validate Binary Search Tree https://leetcode.com/problems/validate-binary-search-tree/

        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBSTHelper(root, -1, "");
        }
        public static bool IsValidBSTHelper(TreeNode node, int parent, string side)
        {
            if (node == null)
            {
                return false;
            }
            if (side == "left")
            {
                if (node.val > parent)
                {
                    return false;
                }
            }
            if (side == "right")
            {
                if (node.val < parent)
                {
                    return false;
                }
            }
            IsValidBSTHelper(node.left, node.val, "left");
            IsValidBSTHelper(node.right, node.val, "right");
            return true;
        }

        //Sum of Path Numbers (medium) https://leetcode.com/problems/sum-root-to-leaf-numbers/
        public int SumNumbers(TreeNode root)
        {
            List<List<int>> listOfLists = new List<List<int>>();
            int totalSum = 0;
            SumNumbersHelper(root, new List<int>(), listOfLists);
            List<string> strList = new List<string>();
            foreach (var list in listOfLists)
            {
                var currStr = string.Empty;
                foreach (var item in list)
                {
                    currStr += item;
                }
                strList.Add(currStr);
            }
            List<int> intList = new List<int>();
            foreach (var item in strList)
            {
                intList.Add(int.Parse(item));
            }

            foreach (var item in intList)
            {
                totalSum += item;
            }

            return totalSum;
        }
        public void SumNumbersHelper(TreeNode node, List<int> list, List<List<int>> listOfLists)
        {
            if (node == null)
            {
                return;
            }
            list.Add(node.val);
            if (node.left == null && node.right == null)
            {
                listOfLists.Add(new List<int>(list));
            }
            SumNumbersHelper(node.left, list, listOfLists);
            SumNumbersHelper(node.right, list, listOfLists);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
