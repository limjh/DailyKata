using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;

namespace SolutionTest
{
    [TestClass]
    public class UnitTest1
    {
        PrintDiamond printDiamond;

   //    --A--   21012
	  // -B-B-
	  // C---C   21012
	  // -B-B-
	  // --A--
	   
	  //---A---  3210123
	  //--B-B--
	  //-C---C-
	  //D-----D  3210123
	  //-C---C-	  
	  // -B-B-
	  // --A--

        [TestInitialize]
        public void setup()
        {
            printDiamond = new PrintDiamond();
        }

        [TestMethod]
        public void A_Z_문자가_아닌_입력에대해_0_size_list를_반환한다()
        {
            List<ArrayList> result = printDiamond.print("1");

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void A_입력()
        {
            List<ArrayList> result = printDiamond.print("A");

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue((string)result[0][0] == "A");
        }


        [TestMethod]
        public void C_입력()
        {
            List<ArrayList> result = printDiamond.print("C");

            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue((string)result[0][3] == "A");
            Assert.IsTrue((string)result[1][2] == "B");
            Assert.IsTrue((string)result[1][4] == "B");
            Assert.IsTrue((string)result[2][1] == "C");
            Assert.IsTrue((string)result[2][5] == "C");
            Assert.IsTrue((string)result[3][2] == "B");
            Assert.IsTrue((string)result[3][4] == "B");
            Assert.IsTrue((string)result[4][3] == "A");
        }
    }
}
