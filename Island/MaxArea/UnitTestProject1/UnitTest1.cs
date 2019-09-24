using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxArea;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        MaxAreaIsland maxArea;

        [TestInitialize]
        public void TestInitialize()
        {
            maxArea = new MaxAreaIsland();
        }

        [TestMethod]
        public void getMaxAreaSize1()
        {
            int[,] input = new int[,] {
                { 0, 0, 1 },
                { 0, 0, 0 },
                { 0, 0, 0 } };
            int expectedMaxArea = 1;

            Assert.AreEqual(expectedMaxArea, maxArea.getMaxAreaSize(input));
        }


        [TestMethod]
        public void getMaxAreaSize2()
        {
            int[,] input = new int[,] {
                { 0, 0, 1 }};
            int expectedMaxArea = 1;

            Assert.AreEqual(expectedMaxArea, maxArea.getMaxAreaSize(input));
        }

        [TestMethod]
        public void 주어진_아이템의_4방향에_위치한_아이템중_1_값이_존재하는지_확인하는_함수1()
        {
            int[,] input = new int[,] {
                { 0, 0, 1 },
                { 0, 1, 1 },
                { 0, 0, 0 } };

            ItemInfo info;
            bool result = maxArea.checkPossibleDirection(input, 1, 1, out info);

            Assert.IsTrue(result);
            Assert.AreEqual(false, info.isLeft);
            Assert.AreEqual(true, info.isRight);
            Assert.AreEqual(false, info.isTop);
            Assert.AreEqual(false, info.isBottom);
        }

        [TestMethod]
        public void 주어진_아이템의_4방향에_위치한_아이템중_1_값이_존재하는지_확인하는_함수2()
        {
            int[,] input = new int[,] {
                { 1, 0, 1 },
                { 0, 1, 0 },
                { 1, 0, 1 } };

            ItemInfo info;
            bool result = maxArea.checkPossibleDirection(input, 1, 1, out info);

            Assert.IsFalse(result);
            Assert.AreEqual(false, info.isLeft);
            Assert.AreEqual(false, info.isRight);
            Assert.AreEqual(false, info.isTop);
            Assert.AreEqual(false, info.isBottom);
        }

        [TestMethod]
        public void 주어진_아이템의_4방향에_위치한_아이템중_1_값이_존재하는지_확인하는_함수3()
        {
            int[,] input = new int[,] {
                { 0, 0, 1 },
                { 0, 1, 0 },
                { 0, 1, 1 } };

            ItemInfo info;
            bool result = maxArea.checkPossibleDirection(input, 1, 1, out info);

            Assert.IsTrue(result);
            Assert.AreEqual(false, info.isLeft);
            Assert.AreEqual(false, info.isRight);
            Assert.AreEqual(false, info.isTop);
            Assert.AreEqual(true, info.isBottom);
        }
    }
}