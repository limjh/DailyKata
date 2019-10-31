using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxArea;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        MaxAreaIsland maxArea;

        [TestInitialize]
        public void TestInitialize()
        {
            maxArea = new MaxAreaIsland();
        }

        [TestMethod]
        public void create_itemConditionMap()
        {
            /*
             *  {0,1,0}
                {1,1,1}
                {0,1,0}

                000  | 010B     | 020
                101R | 111LRTB  | 121L
                200  | 211T     | 220
             */

            int[][] input = new int[3][]
            {
                new int[] {0,1,0},
                new int[] {1,1,1},
                new int[] {0,1,0}
            };

            ItemConditionInfo[,] expected = new ItemConditionInfo[input.GetLength(0), input[0].GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input[0].GetLength(0); j++)
                {
                    expected[i, j] = new ItemConditionInfo();
                }
            }

            expected[0, 0].SetIndexInfo(0, 0, 0);
            expected[0, 1].SetIndexInfo(0, 1, 1);
            expected[0, 2].SetIndexInfo(0, 2, 0);

            expected[1, 0].SetIndexInfo(1, 0, 1);
            expected[1, 1].SetIndexInfo(1, 1, 1);
            expected[1, 2].SetIndexInfo(1, 2, 1);

            expected[2, 0].SetIndexInfo(2, 0, 0);
            expected[2, 1].SetIndexInfo(2, 1, 1);
            expected[2, 2].SetIndexInfo(2, 2, 0);

            expected[0, 1].SetAroundItemExist(false, false, false, true);
            expected[1, 0].SetAroundItemExist(false, true, false, false);
            expected[1, 1].SetAroundItemExist(true, true, true, true);
            expected[1, 2].SetAroundItemExist(true, false, false, false);
            expected[2, 1].SetAroundItemExist(false, false, true, false);

            ItemConditionInfo[,] actual;

            maxArea.CreateConditionMap(input, out actual);

            Assert.AreEqual(expected.Length, actual.Length);

            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));

            Assert.AreEqual(expected[0, 0].info.Count, actual[0, 0].info.Count);
            Assert.AreEqual(expected[0, 1].info.Count, actual[0, 1].info.Count);
            Assert.AreEqual(expected[0, 2].info.Count, actual[0, 2].info.Count);
            Assert.AreEqual(expected[1, 0].info.Count, actual[1, 0].info.Count);
            Assert.AreEqual(expected[1, 1].info.Count, actual[1, 1].info.Count);
            Assert.AreEqual(expected[1, 2].info.Count, actual[1, 2].info.Count);
            Assert.AreEqual(expected[2, 0].info.Count, actual[2, 0].info.Count);
            Assert.AreEqual(expected[2, 1].info.Count, actual[2, 1].info.Count);
            Assert.AreEqual(expected[2, 2].info.Count, actual[2, 2].info.Count);
        }

        

        [TestMethod]
        public void ItemConditionInfo_getRowIndex()
        {
            ItemConditionInfo conditionInfo = new ItemConditionInfo();
            conditionInfo.SetIndexInfo(0, 1, 1);

            Assert.AreEqual(0, conditionInfo.getRowIndex());
        }

        [TestMethod]
        public void ItemConditionInfo_getColIndex()
        {
            ItemConditionInfo conditionInfo = new ItemConditionInfo();
            conditionInfo.SetIndexInfo(0, 1, 1);

            Assert.AreEqual(1, conditionInfo.getColIndex());
        }

        [TestMethod]
        public void ItemConditionInfo_getValue()
        {
            ItemConditionInfo conditionInfo = new ItemConditionInfo();
            conditionInfo.SetIndexInfo(0, 1, 1);

            Assert.AreEqual(1, conditionInfo.getValue());
        }

        [TestMethod]
        public void ItemConditionInfo_isExistArroundIsland()
        {
            ItemConditionInfo conditionInfo1 = new ItemConditionInfo();
            ItemConditionInfo conditionInfo2 = new ItemConditionInfo();
            
            conditionInfo1.SetAroundItemExist(false, true, false, false);
            conditionInfo2.SetAroundItemExist(false, false, false, false);

            Assert.AreEqual(true, conditionInfo1.isExistArroundIsland());
            Assert.AreEqual(false, conditionInfo2.isExistArroundIsland());
        }

        [TestMethod]
        public void ItemConditionInfo_deleteDirection()
        {
            ItemConditionInfo conditionInfo = new ItemConditionInfo();
            conditionInfo.SetIndexInfo(0, 1, 1);
            conditionInfo.SetAroundItemExist(true, true, true, true);

            Assert.AreEqual(true, conditionInfo.isExistLeftIsland());
            Assert.AreEqual(true, conditionInfo.isExistRightIsland());
            Assert.AreEqual(true, conditionInfo.isExistTopIsland());
            Assert.AreEqual(true, conditionInfo.isExistBottomIsland());

            conditionInfo.DeleteLeft();
            Assert.AreEqual(false, conditionInfo.isExistLeftIsland());
            conditionInfo.DeleteRight();
            Assert.AreEqual(false, conditionInfo.isExistRightIsland());
            conditionInfo.DeleteTop();
            Assert.AreEqual(false, conditionInfo.isExistTopIsland());
            conditionInfo.DeleteBottom();
            Assert.AreEqual(false, conditionInfo.isExistBottomIsland());
        }

        [TestMethod]
        public void ItemConditionInfo_deleteFrom()
        {
            ItemConditionInfo conditionInfo = new ItemConditionInfo();
            conditionInfo.SetIndexInfo(0, 1, 1);
            conditionInfo.SetAroundItemExist(true, true, true, true);

            string from = "L";

            conditionInfo.DeleteFrom(from);
            Assert.AreEqual(false, conditionInfo.isExistLeftIsland());
        }

        [TestMethod]
        public void ItemConditionInfo_trackingIsland()
        {
            int[][] input = new int[3][]
            {
                new int[] {0,1,0},
                new int[] {1,1,1},
                new int[] {0,1,0}
            };

            ItemConditionInfo[,] map;
            maxArea.CreateConditionMap(input, out map);
            int indexRow = 0;
            int indexCol = 1;

            List<ItemConditionInfo> result = maxArea.TrakingIsland(ref map, indexRow, indexCol);

            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void MaxAreaOfIsland_01()
        {
            int[][] input = new int[][]
            {
                new int[] {1}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_02()
        {
            int[][] input = new int[1][]
            {
                new int[] {0,0,0,0,0,0}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_03()
        {
            int[][] input = new int[3][]
            {
                new int[] {1, 1},
                new int[] {1, 1},
                new int[] {1, 0}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void MaxAreaOfIsland_04()
        {
            int[][] input = new int[2][]
            {
                new int[] {1, 1, 1, 0},
                new int[] {1, 1, 1, 1}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_05()
        {
            int[][] input = new int[3][]
            {
                new int[] {0,1,0},
                new int[] {1,1,1},
                new int[] {0,1,0}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(5, result);
        }

        /*
         
        {0,0,0,0},
        {1,1,1,0},
        {1,1,1,0},
        {1,1,1,0}


        {000,    010,     020,    030},
        {101RB,  111LRB,  121LB,  130},
        {201RTB, 211LRTB, 221LTB, 230},
        {301RT,  311LRT,  321LT,  330}

        00 : skip
        01 : skip
        02 : skip
        03 : skip

        10 : add (from :  ), delete R, jump R
        11 : add (from : L), delete R, jump R  
        12 : add (from : L), delete B, jump B
        22 : add (from : T), delete L, jump L
        21 : add (from : R), delete L, jump L
        20 : add (from : R), delete T, jump T >> 10 is already add >> delete B, jump B
        30 : add (from : T), delete R, jump R
        31 : add (from : L), delete R, jump R
        32 : add (from : L), delete T, jump T >> 22 is already add >> 

            check list item condition
            10B - 11B - 12 - 20 - 21TB - 22B - 30 - 31T - 32

        10 : already added. delete B, jump B(check B is already added). >> 10 is clean >>
        11 : already added. delete B, jump B(check B is already added). >> 11 is clean >>
        ...
        ...
             */

        [TestMethod]
        public void MaxAreaOfIsland_06()
        {
            int[][] input = new int[5][]
            {
                new int[] {1,1,1,0,0},
                new int[] {0,0,0,0,0},
                new int[] {1,1,1,0,0},
                new int[] {1,1,1,0,0},
                new int[] {1,1,1,0,0}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_07()
        {
            int[][] input = new int[5][]
            {
                new int[] {1,1,1,0,1},
                new int[] {1,1,1,0,1},
                new int[] {1,1,1,0,1},
                new int[] {1,1,1,0,1},
                new int[] {1,1,1,0,1}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_08()
        {
            int[][] input = new int[5][]
            {
                new int[] {1,1,1,0,0},
                new int[] {0,0,0,0,0},
                new int[] {0,1,0,0,1},
                new int[] {1,1,1,0,1},
                new int[] {0,1,0,0,1}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void MaxAreaOfIsland_09()
        {
            int[][] input = new int[8][]
            {
                new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
                new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
            };

            int result = maxArea.MaxAreaOfIsland(input);

            Assert.AreEqual(6, result);
        }
    }
}