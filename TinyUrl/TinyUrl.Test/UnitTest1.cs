using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyUrl;

namespace TinyUrl.Test
{
    [TestClass]
    public class UnitTest1
    {
        UrlBuilder builder;

        [TestInitialize]
        public void TestInitialize()
        {
            builder = new UrlBuilder();
        }

        [TestMethod]
        public void encoding()
        {
            string urlString = "helloworld";
            string encodedString = builder.encode(urlString);

            Assert.IsTrue(builder.urlData.ContainsKey(encodedString));
            Assert.AreEqual("0", encodedString);
        } 

        [TestMethod]
        public void decoding()
        {
            string urlString = "helloworld";

            Assert.IsTrue(0 == urlString.CompareTo(builder.decode((builder.encode(urlString)))));
        }
    }
}
