using System;
using System.Collections.Generic;

namespace _08___Tree_DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node1 = new TreeNode(1);
            node1.left = new TreeNode(2);
            TreeNode node2 = new TreeNode(1);
            node2.right = new TreeNode(2);
            var test = IsSameTree(node1, node2);
        }
        //Binary Tree Path Sum (easy) https://leetcode.com/problems/path-sum/
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.val == sum && root.left == null && root.right == null)
            {
                return true;
            }
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        //All Paths for a Sum (medium) https://leetcode.com/problems/path-sum-ii/
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            List<IList<int>> paths = new List<IList<int>>();
            PathSumHelper(root, sum, new List<int>(), paths);
            return paths;
        }
        public void PathSumHelper(TreeNode node, int sum, List<int> path, List<IList<int>> paths)
        {
            if (node == null)
            {
                return;
            }
            path.Add(node.val);
            if (node.val == sum && node.right == null && node.left == null)
            {
                paths.Add(new List<int>(path));
            }
            PathSumHelper(node.left, sum - node.val, path, paths);
            PathSumHelper(node.right, sum - node.val, path, paths);
            path.RemoveAt(path.Count - 1);
        }

        //257. Binary Tree Paths https://leetcode.com/problems/binary-tree-paths/
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null)
            {
                return new List<string>();
            }
            List<string> paths = new List<string>();
            BinaryTreePathsHelper(root, string.Empty, paths);
            return paths;
        }
        public void BinaryTreePathsHelper(TreeNode node, string path, List<string> paths)
        {
            if (node == null)
            {
                return;
            }
            if (path == string.Empty)
            {
                path += node.val;
            }
            else
            {
                path += "->" + node.val;
            }
            if (node.left == null && node.right == null)
            {
                paths.Add(new string(path));
            }
            if (node.left != null)
            {
                BinaryTreePathsHelper(node.left, path, paths);
            }
            if (node.right != null)
            {
                BinaryTreePathsHelper(node.right, path, paths);
            }
        }

        //Sum of Path Numbers (medium) https://leetcode.com/problems/sum-root-to-leaf-numbers/
        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            List<string> paths = new List<string>();
            SumNumbersHelper(root, string.Empty, paths);
            int totalSum = 0;
            foreach (var item in paths)
            {
                var num = int.Parse(item);
                totalSum += num;
            }
            return totalSum;
        }
        public void SumNumbersHelper(TreeNode node, string path, List<string> paths)
        {
            if (node == null)
            {
                return;
            }
            path += node.val;
            if (node.left == null && node.right == null)
            {
                paths.Add(new string(path));
            }
            SumNumbersHelper(node.left, path, paths);
            SumNumbersHelper(node.right, path, paths);
        }
        //Better solution 
        public int SumNumbers2(TreeNode root)
        {
            return SumNumbers2Helper(root, 0);
        }
        public int SumNumbers2Helper(TreeNode node, int pathSum)
        {
            if (node == null)
            {
                return 0;
            }
            pathSum = 10 * pathSum * node.val;
            if (node.left == null && node.right == null)
            {
                return pathSum;
            }
            return SumNumbers2Helper(node.left, pathSum) + SumNumbers2Helper(node.right, pathSum);
        }

        //Path With Given Sequence (medium) https://leetcode.com/problems/check-if-a-string-is-a-valid-sequence-from-root-to-leaves-path-in-a-binary-tree/
        //Notes: solution is not right, need to review
        public bool IsValidSequence(TreeNode root, int[] arr)
        {
            if (root == null)
            {
                return false;
            }
            return IsValidSequenceHelper(root, arr, new List<int>());
        }
        public bool IsValidSequenceHelper(TreeNode node, int[] arr, List<int> path)
        {
            if (node == null)
            {
                return false;
            }
            path.Add(node.val);
            if (node.left == null && node.right == null)
            {
                int count = arr.Length;
                int i = 0;
                while (i < arr.Length)
                {
                    if (arr[i] == path[i])
                    {
                        count--;
                    }
                    i++;
                }
                if (count == 0)
                {
                    return true;
                }
            }
            return IsValidSequenceHelper(node.left, arr, path) || IsValidSequenceHelper(node.right, arr, path);
        }

        //Count Paths for a Sum(medium) https://leetcode.com/problems/path-sum-iii/
        public int PathSum3(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }
            List<List<int>> paths = new List<List<int>>();
            PathSum3Helper(root, sum, new List<int>(), paths);
            return paths.Count;
        }   
        public void PathSum3Helper(TreeNode node, int sum, List<int> path, List<List<int>> paths)
        {
            if (node == null)
            {
                return;
            }
            path.Add(node.val);
            if (node.val == sum)
            {
                paths.Add(new List<int>(path));
            }
            PathSum3Helper(node.left, sum - node.val, path, paths);
            PathSum3Helper(node.right, sum - node.val, path, paths);
            path.RemoveAt(path.Count - 1);
        }

        //98. Validate Binary Search Tree https://leetcode.com/problems/validate-binary-search-tree/
        //Notes: did not get right, need to review
        public bool IsValidBST(TreeNode root)
        {
            return false;
        }
        public bool IsValidBSTHelper(TreeNode node, int parentValue)
        {
            if (node == null)
            {
                return false;
            }
            
            return false;
        }

        //100. Same Tree https://leetcode.com/problems/same-tree/
        //Notes: did not get right, need to review the solution
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return IsSameTreeHelper(p, q);
        }
        public static bool IsSameTreeHelper(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }
            if (p.val != q.val)
            {
                return false;
            }
            return IsSameTreeHelper(p.left, q.left) && IsSameTreeHelper(p.right, q.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
