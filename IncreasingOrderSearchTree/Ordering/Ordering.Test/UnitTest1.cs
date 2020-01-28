using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordering.Test
{
    [TestClass]
    public class UnitTest1
    {

        //Input: [5,3,6,2,4,null,8,1,null,null,null,7,9]

        //                   5
        //                  / \
        //                3    6
        //               / \    \
        //              2   4    8
        //             /        / \ 
        //            1        7   9

        // [1, 2, 3, 4, 5, 6, 7, 8, 9]

        [TestMethod]
        public void tree_to_ordered_list()
        {
            TreeNode node = new TreeNode(5);
            node.left = new TreeNode(3);
            node.left.left = new TreeNode(2);
            node.left.right = new TreeNode(4);
            node.left.left.left = new TreeNode(1);
            node.left.left.right = null;
            node.right = new TreeNode(6);
            node.right.left = null;
            node.right.right = new TreeNode(8);
            node.right.right.left = new TreeNode(7);
            node.right.right.right = new TreeNode(9);
            node.right.right.left.left = null;
            node.right.right.left.right = null;
            node.right.right.right.left = null;
            node.right.right.right.right = null;

            Solution solution = new Solution();
            List<int> result = new List<int>();
            solution.MakeOrderdList(node, ref result);

            List<int> expectedList = new List<int>();
            expectedList.Add(1);
            expectedList.Add(2);
            expectedList.Add(3);
            expectedList.Add(4);
            expectedList.Add(5);
            expectedList.Add(6);
            expectedList.Add(7);
            expectedList.Add(8);
            expectedList.Add(9);


            CollectionAssert.AreEqual(expectedList, result);
        }
    }
}
