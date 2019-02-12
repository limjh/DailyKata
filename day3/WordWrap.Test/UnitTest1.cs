using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void 클래스_인스턴스를_생성할수_있다()
        {
            WordWrapper wordWrap = new WordWrapper();
        }

        //[TestMethod]
        //public void Wrapping_함수를_수행할수_있다()
        //{
        //    WordWrapper wrapper = new WordWrapper();
        //    wrapper.wordWrapping();
        //}

        [TestMethod]
        public void Wrapping_함수를_호출하여_결과를_return_받을수_있다()
        {
            var wrapper = new WordWrapper();
            String argStr = "testString";
            String resultStr = wrapper.wordWrapping(argStr, 10);

            Assert.AreEqual(resultStr, argStr);
        }


    }
}
