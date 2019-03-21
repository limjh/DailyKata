using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 클래스_인스턴스_생성()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void wrapper_함수_호출()
        {
            var wrapper = new WordWrapper();

            String argStr = "test";
            int argInt = 7;

            Assert.AreEqual(argStr, wrapper.wrapping(argStr, argInt));
        }

        [TestMethod]
        public void wrapper_테스트_01()
        {
            var wrapper = new WordWrapper();

            String argStr = "hello world";
            int argInt = 7;

            String expected = "hello--world";

            Assert.AreEqual(expected, wrapper.wrapping(argStr, argInt));
        }
    }
}