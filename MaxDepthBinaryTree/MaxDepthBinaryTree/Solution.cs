using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxDepthBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        //Given binary tree[3, 9, 20, null, null, 15, 7],

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //return its depth = 3.

        public int MaxDepth(TreeNode root)
        {
            return GetDepth(root, 0);
        }

        public int GetDepth(TreeNode node, int currentDepth)
        {
            if (node == null)
                return currentDepth;

            currentDepth++;

            if (node.left != null && node.right == null)
            {
                currentDepth++;
                currentDepth = GetDepth(node.left, currentDepth);
            } 
            else if (node.left == null && node.right != null)
            {
                currentDepth++;
                currentDepth = GetDepth(node.right, currentDepth);
            }
            else if (node.left != null && node.right != null)
            {
                currentDepth++;
                int depthLeft = 0;
                int depthRight = 0;
                depthLeft = GetDepth(node.left, currentDepth);
                depthRight = GetDepth(node.right, currentDepth);

                currentDepth = depthLeft >= depthRight ? depthLeft : depthRight;
            }

            return currentDepth;
        }
    }
}
