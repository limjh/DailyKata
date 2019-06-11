using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpTest
{
    [TestClass]
    public class UnitTest1
    {

        RegularExp.RegEx regExp;

        [TestInitialize]
        public void TestInitialize()
        {
            regExp = new RegularExp.RegEx();
        }


        [TestMethod]
        public void example_01()
        {
            string input = "aa";
            string pattern = "a";

            bool output = regExp.matching(input, pattern);

            Assert.IsFalse(output);
        }

        [TestMethod]
        public void example_02()
        {
            string input = "aa";
            string pattern = "a*";

            bool output = regExp.matching(input, pattern);

            Assert.IsTrue(output);
        }

        [TestMethod]
        public void example_03()
        {
            string input = "ab";
            string pattern = ".*";

            bool output = regExp.matching(input, pattern);

            Assert.IsTrue(output);
        }

        [TestMethod]
        public void example_04()
        {
            string input = "aab";
            string pattern = "c*a*b";

            bool output = regExp.matching(input, pattern);

            Assert.IsTrue(output);
        }

        [TestMethod]
        public void example_05()
        {
            string input = "mississippi";
            string pattern = "mis*is*p*.";

            bool output = regExp.matching(input, pattern);

            Assert.IsFalse(output);
        }
    }
}
