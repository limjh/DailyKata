using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaximumBinaryTree;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Solution treeMaker;

        [TestInitialize]
        public void TestInitialize()
        {
            treeMaker = new Solution();
        }

        [TestMethod]
        public void 입력받은_배열의_최대값의_인덱스를_반환한다()
        {
            int[] intput = new int[] { 3, 2, 1, 6, 0, 5 };
            int indexMaxNum = 0;
            indexMaxNum = treeMaker.FindMaxNumIndex(intput, 0, 5);

            Assert.AreEqual(indexMaxNum, 3);
            Assert.AreEqual(intput[indexMaxNum], 6);
        }

        [TestMethod]
        public void test_01()
        {
            int[] input = { 1 };
            TreeNode root = treeMaker.ConstructMaximumBinaryTree(input);

            Assert.AreEqual(1, root.val);
            Assert.IsNull(root.left);
            Assert.IsNull(root.right);
        }

        [TestMethod]
        public void test_02()
        {
            int[] input = { 2, 1 };
            TreeNode root = treeMaker.ConstructMaximumBinaryTree(input);

            Assert.AreEqual(2, root.val);
            Assert.IsNull(root.left);
            Assert.AreEqual(1, root.right.val);
        }

        [TestMethod]
        public void test_03()
        {
            int[] input = { 1, 2 };
            TreeNode root = treeMaker.ConstructMaximumBinaryTree(input);

            Assert.AreEqual(2, root.val);
            Assert.AreEqual(1, root.left.val);
            Assert.IsNull(root.right);
        }

        [TestMethod]
        public void test_04()
        {
            int[] input = { 3, 2, 1 };
            TreeNode root = treeMaker.ConstructMaximumBinaryTree(input);

            Assert.AreEqual(3, root.val);
            Assert.IsNull(root.left);
            Assert.AreEqual(2, root.right.val);
            Assert.IsNull(root.right.left);
            Assert.AreEqual(1, root.right.right.val);
        }

        [TestMethod]
        public void test_05()
        {
            int[] input = { 3, 2, 1, 6, 0, 5 };
            TreeNode root = treeMaker.ConstructMaximumBinaryTree(input);

            Assert.AreEqual(6, root.val);
            Assert.AreEqual(3, root.left.val);
            Assert.AreEqual(5, root.right.val);
            Assert.AreEqual(null, root.left.left);
            Assert.AreEqual(2, root.left.right.val);
            Assert.AreEqual(0, root.right.left.val);
            Assert.AreEqual(null, root.right.right);
            Assert.AreEqual(null, root.left.right.left);
            Assert.AreEqual(1, root.left.right.right.val);
        }
    }
}
