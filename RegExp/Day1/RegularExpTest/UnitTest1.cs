using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpTest
{
    [TestClass]
    public class UnitTest1
    {

        RegularExp.Solution regExp;

        [TestInitialize]
        public void TestInitialize()
        {
            regExp = new RegularExp.Solution();
        }

        [TestMethod]
        public void check_isValidInput()
        {
            string validInput = "abcdefghijklmnopqrstuvwxyz";
            string invalidInput1 = "abcdefghijklmnopqrstuvwxyz1";
            string invalidInput2 = "_!@#$";
            string invalidInput3 = " ";

            Assert.IsTrue(regExp.isValidInput(validInput));
            Assert.IsFalse(regExp.isValidInput(invalidInput1));
            Assert.IsFalse(regExp.isValidInput(invalidInput2));
            Assert.IsFalse(regExp.isValidInput(invalidInput3));
        }

        [TestMethod]
        public void check_isValidPattern()
        {
            string validPattern = "abcdefghijklmnopqrstuvwxyz.*";
            string invalidPattern1 = "abcdefghijklmnopqrstuvwxyz12";
            string invalidPattern2 = "_!@#$.*";
            string invalidPattern3 = " ";
            string invalidPattern4 = "\\";

            Assert.IsTrue(regExp.isValidPattern(validPattern));
            Assert.IsFalse(regExp.isValidPattern(invalidPattern1));
            Assert.IsFalse(regExp.isValidPattern(invalidPattern2));
            Assert.IsFalse(regExp.isValidPattern(invalidPattern3));
            Assert.IsFalse(regExp.isValidPattern(invalidPattern4));
        }


        [TestMethod]
        public void example_01()
        {
            string input = "aa";
            string pattern = "a";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                false);
        }

        [TestMethod]
        public void example_02()
        {
            string input = "aa";
            string pattern = "a*";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_SUCCESS);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_03()
        {
            string input = "ab";
            string pattern = ".*";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_SUCCESS);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_04()
        {
            string input = "aab";
            string pattern = "c*a*b";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_SUCCESS);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_05()
        {
            string input =   "mississippi";
            string pattern = "mis*is*p*.";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                false);
        }

        [TestMethod]
        public void example_06()
        {
            string input = "aaa";
            string pattern = "aaaa";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                false);
        }

        [TestMethod]
        public void example_07()
        {
            string input = "aaa";
            string pattern = "ab*ac*a";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_08()
        {
            string input = "aaa";
            string pattern = "ab*a";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                false);
        }


        [TestMethod]
        public void example_09()
        {
            string input = "aaca";
            string pattern = "ab*a*c*a";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_10()
        {
            string input = "abcd";
            string pattern = "d*";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                false);
        }

        [TestMethod]
        public void example_11()
        {
            string input = "aaa";
            string pattern = ".*";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }

        [TestMethod]
        public void example_12()
        {
            string input = "a";
            string pattern = "ab*";

            //Assert.AreEqual(
            //    regExp.isMatch(input, pattern),
            //    ErrorCodes.ERROR_MATCHING_FAIL);
            Assert.AreEqual(
                regExp.IsMatch(input, pattern),
                true);
        }
    }
}
