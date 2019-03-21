using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void wrapper클래스인스턴스를_생성할_수_있다()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void wrapper클래스를_이용해_string을_stringArray_로_할_수_있다()
        {
            char[] expectedArray = { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
            String arg = "hello world";

            var wrapper = new WordWrapper();

            char[] resultArray = wrapper.MakeStringArray(arg);

            Assert.AreEqual(resultArray.Length, expectedArray.Length);
            Assert.AreEqual(resultArray[0], expectedArray[0]);
            Assert.AreEqual(resultArray[5], expectedArray[5]);
            Assert.AreEqual(resultArray[10], expectedArray[10]);
        }

        [TestMethod]
        public void 다음_문자열을_인자로하여_1번_결과를_리턴받을수_있다()
        {
            String argString = "test";
            int argInt = 7;
            String expectedResult = "test";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        public void 다음_문자열을_인자로하여_2번_결과를_리턴받을수_있다()
        {
            String argString = "hello world";
            int argInt = 7;
            String expectedResult = "hello--world";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        public void 다음_문자열을_인자로하여_3번_결과를_리턴받을수_있다()
        {
            String argString = "a lot of words for a single line";
            int argInt = 10;
            String expectedResult = "a lot of--words for--a single--line";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }
    }
}
