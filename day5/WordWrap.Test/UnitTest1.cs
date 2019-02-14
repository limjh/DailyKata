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
        public void 클래스인스턴스를_생성할_수_있다()
        {
            var wrapper = new WordWrapper();
        }

        [TestMethod]
        public void 문자열을_공백으로_구분하여_arraylist_를_리턴할_수_있다()
        {
            var wrapper = new WordWrapper();
            String arg = "a lot of words for a single line";
            ArrayList expectedList = new ArrayList();
            expectedList.Add("a");
            expectedList.Add("lot");
            expectedList.Add("of");
            expectedList.Add("words");
            expectedList.Add("for");
            expectedList.Add("a");
            expectedList.Add("single");
            expectedList.Add("line");

            ArrayList resultList = wrapper.makeStringArrayList(arg);

            Assert.AreEqual(resultList.Count, expectedList.Count);
            Assert.IsTrue(resultList.IndexOf("a") == expectedList.IndexOf("a"));
            Assert.IsTrue(resultList.IndexOf("of") == expectedList.IndexOf("of"));
            Assert.IsTrue(resultList.IndexOf("line") == expectedList.IndexOf("line"));
        }

        [TestMethod]
        public void 문자열을_입력받아_
    }
}
