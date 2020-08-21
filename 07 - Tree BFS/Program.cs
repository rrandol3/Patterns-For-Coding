using System;
using System.Diagnostics;
using System.Threading;

namespace _07___Tree_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(3);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(5);
            tree.right.left = new TreeNode(6);
            tree.right.right = new TreeNode(7);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            var list = TreePractice.LevelOrderTraversal(tree);
            stopwatch1.Stop();
            Console.WriteLine($"Without for loop: {stopwatch1.Elapsed}");

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var list2 = TreePractice.LevelOrderTraversal2(tree);
            stopwatch2.Stop();
            Console.WriteLine($"With for loop: {stopwatch2.Elapsed}");
            //foreach (var item in list)
            //{
            //    Console.Write($"{item} ");
            //}
        }
    }
}
