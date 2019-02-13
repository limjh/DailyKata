using System;
using System.Collections.Generic;
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
        public void 클래스_인스턴스를_생성할_수_있다()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void 클래스_인스턴스를_이용해_wrapper_함수를_호출하여_String을_리턴받을_수_있다()
        {
            var wrapper = new WordWrapper();
            String arg1 = "hello world";
            int arg2 = 10;
            String result = wrapper.wrapping(arg1, arg2);

            Assert.AreEqual(arg1, result);
        }

        [TestMethod]
        public void test_문자열과_7_값을_입력받아_test_문자열을_return_받을_수_있다()
        {
            var wrapper = new WordWrapper();

            String expected = "test";
            String arg1 = "test";
            int arg2 = 7;

            String result = wrapper.wrapping(arg1, arg2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void hello_world_문자열과_7_값을_입력받아_hello_zz_world_문자열을_return_받을_수_있다()
        {
            var wrapper = new WordWrapper();

            String expected = "hello--world";
            String arg1 = "hello world";
            int arg2 = 7;
            String result = wrapper.wrapping(arg1, arg2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void 단어와_공백을_각각의_String_원소로하는_vector를_만들_수_있다()
        {
            var wrapper = new WordWrapper();
            List<String> expectedList = new List<string>();
            expectedList.Add("a");
            expectedList.Add(" ");
            expectedList.Add("lot");
            expectedList.Add(" ");
            expectedList.Add("of");
            expectedList.Add(" ");
            expectedList.Add("words");
            expectedList.Add(" ");
            expectedList.Add("for");
            expectedList.Add(" ");
            expectedList.Add("a");
            expectedList.Add(" ");
            expectedList.Add("single");
            expectedList.Add(" ");
            expectedList.Add("line");

            String arg1 = "a lot of words for a single line";
            List<String> resultList = wrapper.makeStringVector(arg1);

            Assert.AreEqual(resultList.Count, expectedList.Count);
        }

        [TestMethod]
        public void a_lot_of_words_for_a_single_line_문자열과_10_값을_입력받아_a_lot_of_zz_words_for_zz_a_single_zz_line_문자열을_return_받을_수_있다()
        {
            var wrapper = new WordWrapper();

            String expected = "a lot of--words for--a single--line";
            String arg1 = "a lot of words for a single line";
            int arg2 = 10;
            String result = wrapper.wrapping(arg1, arg2);

            Assert.AreEqual(expected, result);
        }
    }
}
