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

        [DataRow("test", "test", 7)]
        [DataRow("hello--world", "hello world", 7)]
        [DataRow("a lot of--words for--a single--line", "a lot of words for a single line", 10)]
        [DataRow("this--is a--test", "this is a test", 4)]
        [DataRow("a long--word", "a longword", 6)]
        [DataRow("areall--ylongw--ord", "areallylongword", 6)]
        [DataRow("word", "word", 6)]
        [DataRow("word", "word", 5)]
        [DataRow("word", "word", 4)]
        [DataRow("wor--d", "word", 3)]
        [DataRow("word--word", "word word", 4)]
        [DataRow("word--word", "word word", 5)]
        [DataRow("word--word", "word word", 7)]
        [DataRow("word word--word", "word word word", 10)]
        [DataRow("word word--word", "word word word", 12)]
        [DataRow("word--word--word", "word word word", 5)]
        [DataRow("a lot of--words", "a lot of words", 10)]
        [DataRow("a lot of--words for--a single", "a lot of words for a single", 10)]
        [DataTestMethod]
        public void 다음의_테스트를_모두_수행할_수_있다(string Expected, string Given, int Length)
        {
            var wrapper = new WordWrapper();
            Assert.AreEqual(Expected, wrapper.Wrapping(Given, Length));
        }
    }
}
