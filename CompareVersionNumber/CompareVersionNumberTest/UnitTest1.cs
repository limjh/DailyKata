using System;
using CompareVersionNumber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompareVersionNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        CompareVersionClass Comparer;

        [TestInitialize]
        public void TestInitialize()
        {
            Comparer = new CompareVersionClass();
        }

        [TestMethod]
        public void TestMethod_spliter01()
        {
            string input = "7.5.2.4";
            string[] expected = { "7", "5", "2", "4" };

            string[] result = Comparer.Spliter(input);

            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
            Assert.AreEqual(expected[2], result[2]);
            Assert.AreEqual(expected[3], result[3]);
        }

        [TestMethod]
        public void TestMethod_spliter02()
        {
            string input = "1.0.0.002";
            string[] expected = { "1", "0", "0", "002" };

            string[] result = Comparer.Spliter(input);

            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
            Assert.AreEqual(expected[2], result[2]);
            Assert.AreEqual(expected[3], result[3]);
        }

        [TestMethod]
        public void TestMethod_stringArraytoIntArray01()
        {
            string[] input = { "1", "0", "0", "002" };
            int[] expected = { 1, 0, 0, 2 };

            int[] result = Comparer.StringArraytoIntArray(input);

            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
            Assert.AreEqual(expected[2], result[2]);
            Assert.AreEqual(expected[3], result[3]);
        }

        [TestMethod]
        public void TestMethod_compareVersion01()
        {
            string input1 = "0.1";
            string input2 = "1.1";

            Assert.AreEqual(Comparer.CompareVersion(input1, input2), -1);
        }

        [TestMethod]
        public void TestMethod_compareVersion02()
        {
            string input1 = "1.0.1";
            string input2 = "1";

            Assert.AreEqual(Comparer.CompareVersion(input1, input2), 1);
        }

        [TestMethod]
        public void TestMethod_compareVersion03()
        {
            string input1 = "7.5.2.4";
            string input2 = "7.5.3";

            Assert.AreEqual(Comparer.CompareVersion(input1, input2), -1);
        }

        [TestMethod]
        public void TestMethod_compareVersion04()
        {
            string input1 = "1.01";
            string input2 = "1.001";

            Assert.AreEqual(Comparer.CompareVersion(input1, input2), 0);
        }

        [TestMethod]
        public void TestMethod_compareVersion05()
        {
            string input1 = "1.0";
            string input2 = "1.0.0";

            Assert.AreEqual(Comparer.CompareVersion(input1, input2), 0);
        }
    }
}
