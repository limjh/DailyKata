using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver;

namespace SudokuTest
{
    [TestClass]
    public class UnitTest1
    {
        Sudoku sudoku;

        [TestInitialize]
        public void TestInitialize()
        {
            sudoku = new Sudoku();
        }

        [TestMethod]
        public void Solve_and_Validator()
        {
            int[,] question = new int[9, 9];
            int[,] answer = sudoku.solve(question);

            Assert.IsFalse(sudoku.validate(answer));
        }

        [TestMethod]
        public void check_1_row_validate()
        {
            int[] array1 = new int[] { 0, 1, 0, 9, 0, 0, 0, 8, 7 };
            int[] array2 = new int[] { 2, 1, 5, 9, 6, 4, 3, 8, 8 };
            int[] array3 = new int[] { 2, 1, 5, 9, 6, 4, 3, 8, 9 };
            int[] array4 = new int[] { 1, 1, 5, 9, 6, 4, 3, 8, 7 };
            int[] array5 = new int[] { 2, 1, 5, 3, 6, 4, 3, 8, 7 };
            int[] array6 = new int[] { 2, 1, 5, 9, 6, 4, 3, 8, 7 };

            Assert.AreEqual(false, sudoku.checkOneRow(array1));
            Assert.AreEqual(false, sudoku.checkOneRow(array2));
            Assert.AreEqual(false, sudoku.checkOneRow(array3));
            Assert.AreEqual(false, sudoku.checkOneRow(array4));
            Assert.AreEqual(false, sudoku.checkOneRow(array5));
            Assert.AreEqual(true, sudoku.checkOneRow(array6));
        }

        [TestMethod]
        public void convert_row_to_colum()
        {
            int[,] array2D = new int[,]
                {{0, 1, 0,  9, 0, 0,  0, 8, 7},
                {0, 0, 0,  2, 0, 0,  0, 0, 6},
                {0, 0, 0,  0, 0, 3,  2, 1, 0},

                {0, 0, 1,  0, 4, 5,  0, 0, 0},
                {0, 0, 2,  1, 0, 8,  9, 0, 0},
                {0, 0, 0,  3, 2, 0,  6, 0, 0},

                {0, 9, 3,  8, 0, 0,  0, 0, 0},
                {7, 0, 0,  0, 0, 1,  0, 0, 0},
                {5, 8, 0,  0, 0, 6,  0, 9, 0}};

            int[,] resultArray2D = sudoku.convertRowToCol(array2D);

            Assert.AreEqual(resultArray2D[0, 0], 0);
            Assert.AreEqual(resultArray2D[0, 8], 5);
            Assert.AreEqual(resultArray2D[8, 0], 7);
            Assert.AreEqual(resultArray2D[8, 1], 6);
            Assert.AreEqual(resultArray2D[3, 5], 3);
        }
    }
}
