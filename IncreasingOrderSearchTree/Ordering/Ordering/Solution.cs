using System;
using System.Collections.Generic;

namespace Ordering
{
 
    public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
    }
 

    public class Solution
    {
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<int> list = new List<int>();

            MakeOrderdList(root, ref list);

            if (list.Count == 0)
                return null;

            TreeNode tmpNode = null;
            TreeNode tmpRoot = null;
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode node = new TreeNode(list[i]);

                if (i == 0)
                    tmpRoot = node;

                if (tmpNode != null)
                    tmpNode.right = node;

                tmpNode = node;
            }

            return tmpRoot;
        }

        //Input: [5,3,6,2,4,null,8,1,null,null,null,7,9]

        //                   5
        //                  / \
        //                3    6
        //               / \    \
        //              2   4    8
        //             /        / \ 
        //            1        7   9

        // [1, 2, 3, 4, 5, 6, 7, 8, 9]

        public void MakeOrderdList(TreeNode node, ref List<int> list)
        {
            if (node == null)
                return;

            MakeOrderdList(node.left, ref list);

            list.Add(node.val);

            MakeOrderdList(node.right, ref list);
        }
    }
}
