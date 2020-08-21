﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07___Tree_BFS
{
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
        public TreeNode(int val)
        {
            this.val = val;
        }
    }
}