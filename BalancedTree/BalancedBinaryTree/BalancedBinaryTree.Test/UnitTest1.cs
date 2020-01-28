using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalancedBinaryTree.Test
{
    [TestClass]
    public class UnitTest1
    {

          //  3
          // / \
          //9  20
          //  /  \
          // 15   7

        [TestMethod]
        public void TestMethod1()
        {

            TreeNode node = new TreeNode(3);
            node.left = new TreeNode(9);
            node.left.left = null;
            node.left.right = null;

            node.right = new TreeNode(20);
            node.right.left = new TreeNode(15);
            node.right.right = new TreeNode(7);
            node.right.left.left = null;
            node.right.left.right = null;
            node.right.right.left = null;
            node.right.right.right = null;

            Solution solution = new Solution();
            int left = solution.GetNodeDepth(node.left);
            int right = solution.GetNodeDepth(node.right);

            Assert.AreEqual(1, left);
            Assert.AreEqual(2, right);
        }

        //   1
        //  2 2
        // 3   3
        //4     4

        [TestMethod]
        public void TestMethod2()
        {

            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(3);
            node.left.right = null;
            node.left.left.left = new TreeNode(4);
            node.left.left.right = null;
            node.left.left.left.left = null;
            node.left.left.left.right = null;

            node.right = new TreeNode(2);
            node.right.left = null;
            node.right.right = new TreeNode(3);
            node.right.right.left = null;
            node.right.right.right = new TreeNode(3);
            node.right.right.right.left = null;
            node.right.right.right.right = null;

            Solution solution = new Solution();
            int left = solution.GetNodeDepth(node.left);
            int right = solution.GetNodeDepth(node.right);

            Assert.AreEqual(3, left);
            Assert.AreEqual(3, right);

            Assert.IsFalse(solution.IsBalanced(node));
        }
    }
}
