using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Wrapper클래스인스턴스를_생성할_수_있다()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void Wrapper클래스_함수를_통해_문자열을_arrayList로_변환할_수_있다()
        {
            String arg = "hello world";
            ArrayList arrayList = new ArrayList();
            arrayList.Add("hello");
            arrayList.Add(" ");
            arrayList.Add("world");

            var wrapper = new WordWrapper();
            ArrayList resultArrayList = wrapper.MakeArrayList(arg);

            Assert.AreEqual(arrayList.Count, resultArrayList.Count);
            Assert.AreEqual(arrayList.IndexOf("hello"), resultArrayList.IndexOf("hello"));
            Assert.AreEqual(arrayList.IndexOf(" "), resultArrayList.IndexOf(" "));
            Assert.AreEqual(arrayList.IndexOf("world"), resultArrayList.IndexOf("world"));
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

        [TestMethod]
        public void 다음_문자열을_인자로하여_4번_결과를_리턴받을수_있다()
        {
            String argString = "this is a test";
            int argInt = 4;
            String expectedResult = "this--is a--test";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        public void 다음_문자열을_인자로하여_5번_결과를_리턴받을수_있다()
        {
            String argString = "a longword";
            int argInt = 6;
            String expectedResult = "a long--word";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        public void 다음_문자열을_인자로하여_6번_결과를_리턴받을수_있다()
        {
            String argString = "areallylongword";
            int argInt = 6;
            String expectedResult = "areall--ylongw--ord";

            var wrapper = new WordWrapper();
            String resultString = wrapper.Wrapping(argString, argInt);

            Assert.AreEqual(expectedResult, resultString);
        }
    }
}
