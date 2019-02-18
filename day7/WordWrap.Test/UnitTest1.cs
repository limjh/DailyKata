using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void WordWrapper클래스_인스턴스를_생성할수_있다()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void String을_인자로하여_ArrayList를_반환할수_있다()
        {
            String arg = "a lot of words for a single line";
            ArrayList arrayList = new ArrayList();
            arrayList.Add("a");
            arrayList.Add("lot");
            arrayList.Add("of");
            arrayList.Add("words");
            arrayList.Add("for");
            arrayList.Add("a");
            arrayList.Add("single");
            arrayList.Add("line");

            var wrapper = new WordWrapper();
            ArrayList resultList = wrapper.MakeArrayList(arg);

            Assert.AreEqual(arrayList.IndexOf("a"), resultList.IndexOf("a"));
            Assert.AreEqual(arrayList.IndexOf("words"), resultList.IndexOf("words"));
            Assert.AreEqual(arrayList.IndexOf("line"), resultList.IndexOf("line"));
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
