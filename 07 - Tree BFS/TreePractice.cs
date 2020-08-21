using System;
using System.Collections.Generic;
using System.Text;

namespace _07___Tree_BFS
{
    public static class TreePractice
    {
        public static List<int> LevelOrderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var curr = q.Dequeue();
                list.Add(curr.val);
                if (curr.left != null)
                {
                    q.Enqueue(curr.left);
                }
                if (curr.right != null)
                {
                    q.Enqueue(curr.right);
                }
            }
            return list;
        }
        public static List<int> LevelOrderTraversal2(TreeNode root)
        {
            List<int> list = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    var curr = q.Dequeue();
                    list.Add(curr.val);
                    if (curr.left != null)
                    {
                        q.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        q.Enqueue(curr.right);
                    }
                }
            }
            return list;
        }
    }
}
