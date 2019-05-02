using System;
using System.Collections;
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

            Assert.IsFalse(sudoku.finalValidate(answer));
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
        public void get_selected_row()
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

            int rowIndex = 7;

            int[] rowArray = sudoku.getSelectedRow(rowIndex, array2D);

            Assert.AreEqual(rowArray[0], array2D[rowIndex, 0]);
            Assert.AreEqual(rowArray[1], array2D[rowIndex, 1]);
            Assert.AreEqual(rowArray[2], array2D[rowIndex, 2]);
            Assert.AreEqual(rowArray[8], array2D[rowIndex, 8]);
        }

        [TestMethod]
        public void get_selected_col()
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

            int columnIndex = 7;

            int[] colArray = sudoku.getSelectedColumn(columnIndex, array2D);

            Assert.AreEqual(colArray[0], array2D[0, columnIndex]);
            Assert.AreEqual(colArray[1], array2D[1, columnIndex]);
            Assert.AreEqual(colArray[2], array2D[2, columnIndex]);
            Assert.AreEqual(colArray[8], array2D[8, columnIndex]);
        }

        [TestMethod]
        public void get_Selected_3x3_Array()
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

            int rowIndex = 2;
            int colIndex = 0;
            int[] resultArray = sudoku.getSelected3x3Array(rowIndex, colIndex, array2D);

            Assert.AreEqual(resultArray[0], array2D[6, 0]);
            Assert.AreEqual(resultArray[1], array2D[6, 1]);
            Assert.AreEqual(resultArray[2], array2D[6, 2]);

            Assert.AreEqual(resultArray[3], array2D[7, 0]);
            Assert.AreEqual(resultArray[4], array2D[7, 1]);
            Assert.AreEqual(resultArray[5], array2D[7, 2]);

            Assert.AreEqual(resultArray[6], array2D[8, 0]);
            Assert.AreEqual(resultArray[7], array2D[8, 1]);
            Assert.AreEqual(resultArray[8], array2D[8, 2]);
        }

        [TestMethod]
        public void validate_check()
        {
            int[,] invalidArray2D = new int[,]
                {{0, 1, 0,  9, 0, 0,  0, 8, 7},
                {0, 0, 0,  2, 0, 0,  0, 0, 6},
                {0, 0, 0,  0, 0, 3,  2, 1, 0},

                {0, 0, 1,  0, 4, 5,  0, 0, 0},
                {0, 0, 2,  1, 0, 8,  9, 0, 0},
                {0, 0, 0,  3, 2, 0,  6, 0, 0},

                {0, 9, 3,  8, 0, 0,  0, 0, 0},
                {7, 0, 0,  0, 0, 1,  0, 0, 0},
                {5, 8, 0,  0, 0, 6,  0, 9, 0}};

            int[,] validArray2D = new int[,]
                {{2, 1, 5,  9, 6, 4,  3, 8, 7},
                {8, 3, 9,  2, 1, 7,  4, 5, 6},
                {6, 4, 7,  5, 8, 3,  2, 1, 9},

                {9, 7, 1,  6, 4, 5,  8, 2, 3},
                {3, 6, 2,  1, 7, 8,  9, 4, 5},
                {4, 5, 8,  3, 2, 9,  6, 7, 1},

                {1, 9, 3,  8, 5, 2,  7, 6, 4},
                {7, 2, 6,  4, 9, 1,  5, 3, 8},
                {5, 8, 4,  7, 3, 6,  1, 9, 2}};

            int[,] validArray2D2 = new int[,]
                {{5, 8, 3,  2, 1, 9,  6, 4, 7},
                {4, 7, 2,  3, 5, 6,  9, 8, 1},
                {1, 9, 6,  7, 8, 4,  3, 2, 5},

                {8, 3, 4,  6, 7, 2,  1, 5, 9},
                {6, 1, 5,  8, 9, 3,  4, 7, 2},
                {7, 2, 9,  1, 4, 5,  8, 3, 6},

                {2, 6, 8,  9, 3, 7,  5, 1, 4},
                {3, 5, 7,  4, 6, 1,  2, 9, 8},
                {9, 4, 1,  5, 2, 8,  7, 6, 3}};

            Assert.AreEqual(false, sudoku.finalValidate(invalidArray2D));
            Assert.AreEqual(true, sudoku.finalValidate(validArray2D));
            Assert.AreEqual(true, sudoku.finalValidate(validArray2D2));
        }

        [TestMethod]
        public void check_validate()
        {
            int[,] question = new int[,]
                {{0, 4, 0,  3, 5, 2,  7, 8, 6},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {0, 2, 0,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  0, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  0, 4, 0},
                {1, 3, 6,  4, 7, 8,  9, 0, 5},
                {4, 8, 9,  2, 3, 5,  0, 7, 0}};


            Assert.AreEqual(true, sudoku.validate(question));
        }

        [TestMethod]
        public void getNeedNumList()
        {
            int[,] question = new int[,]
                {{0, 4, 0,  3, 5, 2,  7, 8, 9},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {0, 2, 0,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  0, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  0, 4, 0},
                {1, 3, 6,  4, 7, 8,  9, 2, 5},
                {4, 8, 9,  2, 3, 5,  6, 7, 1}};

            ArrayList result = sudoku.getNeedNumList(sudoku.getSelectedRow(0, question));

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, (int)result[0]);
            Assert.AreEqual(6, (int)result[1]);
        }

        [TestMethod]
        public void removeExitNum()
        {
            int[,] question = new int[,]
                {{0, 4, 0,  3, 5, 2,  7, 8, 9},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {0, 2, 0,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  0, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  0, 4, 0},
                {1, 3, 6,  4, 7, 8,  9, 2, 5},
                {4, 8, 9,  2, 3, 5,  6, 7, 1}};

            ArrayList list = sudoku.makeArrayList();
            ArrayList result = sudoku.removeExitNum(list, sudoku.getSelectedRow(0, question));

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, (int)result[0]);
            Assert.AreEqual(6, (int)result[1]);
        }

        [TestMethod]
        public void solve_possible_position()
        {
            int[,] question = new int[,]
                {{0, 4, 0,  3, 5, 2,  7, 8, 6},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {0, 2, 0,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  0, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  0, 4, 0},
                {1, 3, 6,  4, 7, 8,  9, 2, 5},
                {4, 8, 9,  2, 3, 5,  6, 7, 1}};

            int[,] answer = new int[,]
                {{9, 4, 1,  3, 5, 2,  7, 8, 6},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {5, 2, 8,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  9, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  8, 4, 3},
                {1, 3, 6,  4, 7, 8,  9, 2, 5},
                {4, 8, 9,  2, 3, 5,  6, 7, 1}};

            int[,] result = sudoku.solve(question);

            Assert.AreEqual(answer[0, 0], result[0, 0]);
            Assert.AreEqual(answer[0, 1], result[0, 1]);
            Assert.AreEqual(answer[2, 0], result[2, 0]);
            Assert.AreEqual(answer[2, 1], result[2, 1]);
            Assert.AreEqual(answer[3, 3], result[3, 3]);
            Assert.AreEqual(answer[6, 6], result[6, 6]);
            Assert.AreEqual(answer[6, 8], result[6, 8]);
        }

        [TestMethod]
        public void solve_level01()
        {
            int[,] question = new int[,]
                {{9, 4, 1,  0, 0, 2,  0, 0, 0},
                {0, 0, 0,  0, 0, 0,  0, 5, 0},
                {0, 0, 0,  7, 0, 0,  1, 3, 0},

                {8, 0, 0,  0, 0, 3,  0, 6, 0},
                {3, 6, 2,  1, 0, 7,  5, 9, 4},
                {0, 9, 0,  5, 0, 0,  0, 0, 8},

                {0, 5, 7,  0, 0, 1,  0, 0, 0},
                {0, 3, 0,  0, 0, 0,  0, 0, 0},
                {0, 0, 0,  2, 0, 0,  6, 7, 1}};


            int[,] answer = new int[,]
                {{9, 4, 1,  3, 5, 2,  7, 8, 6},
                {6, 7, 3,  8, 1, 9,  4, 5, 2},
                {5, 2, 8,  7, 6, 4,  1, 3, 9},

                {8, 1, 5,  9, 4, 3,  2, 6, 7},
                {3, 6, 2,  1, 8, 7,  5, 9, 4},
                {7, 9, 4,  5, 2, 6,  3, 1, 8},

                {2, 5, 7,  6, 9, 1,  8, 4, 3},
                {1, 3, 6,  4, 7, 8,  9, 2, 5},
                {4, 8, 9,  2, 3, 5,  6, 7, 1}};

            int[,] result = sudoku.solve(question);

            Assert.AreEqual(answer[0, 0], result[0, 0]);
            Assert.AreEqual(answer[0, 1], result[0, 1]);
            Assert.AreEqual(answer[2, 0], result[2, 0]);
            Assert.AreEqual(answer[2, 1], result[2, 1]);
            Assert.AreEqual(answer[3, 3], result[3, 3]);
            Assert.AreEqual(answer[6, 6], result[6, 6]);
            Assert.AreEqual(answer[6, 8], result[6, 8]);
        }

        [TestMethod]
        public void solve_level02()
        {
            int[,] question = new int[,]
                {{4, 3, 5,  0, 6, 1,  0, 7, 0},
                {7, 6, 0,  0, 0, 0,  3, 0, 0},
                {0, 0, 0,  0, 0, 0,  0, 4, 0},

                {0, 0, 0,  8, 0, 0,  0, 0, 3},
                {3, 0, 0,  5, 7, 9,  0, 0, 4},
                {8, 0, 0,  0, 0, 4,  0, 0, 0},

                {0, 8, 0,  0, 0, 0,  0, 0, 0},
                {0, 0, 1,  0, 0, 0,  0, 9, 7},
                {0, 9, 0,  7, 4, 0,  5, 6, 1}};


            int[,] answer = new int[,]
                {{4, 3, 5,  9, 6, 1,  2, 7, 8},
                {7, 6, 9,  4, 8, 2,  3, 1, 5},
                {1, 2, 8,  3, 5, 7,  9, 4, 6},

                {9, 5, 4,  8, 1, 6,  7, 2, 3},
                {3, 1, 2,  5, 7, 9,  6, 8, 4},
                {8, 7, 6,  2, 3, 4,  1, 5, 9},

                {6, 8, 7,  1, 9, 5,  4, 3, 2},
                {5, 4, 1,  6, 2, 3,  8, 9, 7},
                {2, 9, 3,  7, 4, 8,  5, 6, 1}};

            int[,] result = sudoku.solve(question);

            writeArray(result);

            Assert.AreEqual(answer[0, 0], result[0, 0]);
            Assert.AreEqual(answer[0, 1], result[0, 1]);
            Assert.AreEqual(answer[2, 0], result[2, 0]);
            Assert.AreEqual(answer[2, 1], result[2, 1]);
            Assert.AreEqual(answer[3, 3], result[3, 3]);
            Assert.AreEqual(answer[6, 6], result[6, 6]);
            Assert.AreEqual(answer[6, 8], result[6, 8]);
        }

        public void writeArray(int[,] array)
        {
            for (int i = 0; i < 9; i++)
            {
                 System.Diagnostics.Debug.WriteLine(array[i, 0]+" "+array[i, 1]+" "+array[i, 2]+ "  " +
                     array[i, 3] + " " + array[i, 4] + " " + array[i, 5] + "  " +
                     array[i, 6] + " " + array[i, 7] + " " + array[i, 8]);
                System.Diagnostics.Debug.WriteLine(" ");
            }
        }
    }
}
