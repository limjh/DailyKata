using System;
using System.Collections;
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
        public void 클래스인스턴스를_생성할수_있다()
        {
            WordWrapper wrapper = new WordWrapper();
        }

        [TestMethod]
        public void argument로_String과_int값을_전달받아_전달받은_String을_반환하는_함수를_호출할_수있다()
        {

            String argStr = "test";
            String expected = "test";
            int argInt = 10;

            var wrapper = new WordWrapper();
            String result = wrapper.wrapping(argStr, argInt);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void argument_String을_공백_기준으로_나누어_arraylist를_생성할_수_있다()
        {
            String argTest = "hello world I am grute";

            ArrayList expectedList = new ArrayList();
            expectedList.Add("hello");
            expectedList.Add("world");
            expectedList.Add("I");
            expectedList.Add("am");
            expectedList.Add("grute");

            var wrapper = new WordWrapper();

            ArrayList resultList = wrapper.makeArrayList(argTest);

            Assert.AreEqual(resultList.Count, expectedList.Count);
            Assert.AreEqual(resultList.IndexOf("hello"), expectedList.IndexOf("hello"));
            Assert.AreEqual(resultList.IndexOf("I"), expectedList.IndexOf("I"));
            Assert.AreEqual(resultList.IndexOf("grute"), expectedList.IndexOf("grute"));
        }

        [TestMethod]
        public void test_7_을_arg로_입력받아_test_를_반환한다()
        {
            String argStr = "test";
            String expected = "test";
            int argInt = 7;

            var wrapper = new WordWrapper();
            String result = wrapper.wrapping(argStr, argInt);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void hello_world_7_을_arg로_입력받아_hello__world_를_반환한다()
        {
            String argStr = "hello world";
            String expected = "hello--world";
            int argInt = 7;

            var wrapper = new WordWrapper();
            String result = wrapper.wrapping(argStr, argInt);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void a_lot_of_words_for_a_single_line_10_을_arg로_입력받아_a_lot_of__words_for__a_single__line_를_반환한다()
        {
            String argStr = "a lot of words for a single line";
            String expected = "a lot of--words for--a single--line";
            int argInt = 10;

            var wrapper = new WordWrapper();
            String result = wrapper.wrapping(argStr, argInt);

            Assert.AreEqual(result, expected);
        }
    }
}
