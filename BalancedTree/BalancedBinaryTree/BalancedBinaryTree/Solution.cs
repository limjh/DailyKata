
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBinaryTree
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

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            if (!IsBalancedSubNode(root.left))
                return false;
            if (!IsBalancedSubNode(root.right))
                return false;

            return true;
        }

        public bool IsBalancedSubNode(TreeNode root)
        {
            int leftDepth = GetNodeDepth(root.left);
            int rightDepth = GetNodeDepth(root.right);

            bool result = Math.Abs(leftDepth - rightDepth) > 1 ? false : true;

            return result;
        }

        public int GetNodeDepth(TreeNode root)
        {
            int depth = 0;

            if (root == null)
                return depth;

            int leftDepth = GetNodeDepth(root.left);
            int rightDepth = GetNodeDepth(root.right);

            if (leftDepth >= rightDepth)
            {
                depth = leftDepth + 1;
            } else
            {
                depth = rightDepth + 1;
            }
            
            return depth;
        }
    }
}
