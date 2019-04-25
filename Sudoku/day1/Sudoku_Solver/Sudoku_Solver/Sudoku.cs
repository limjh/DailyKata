using System;
using System.Collections;

namespace Sudoku_Solver
{
    public class Sudoku
    {
        public Sudoku()
        {
        }

        public int[,] solve(int[,] question)
        {
            int[,] result;

            while(true)
            {
                result = solvePossibleNum(question);

                if (!validate(result))
                    break;

                if (!isPossibleToSolve(result))
                    break;
            }
           
            
            return result;
        }

        public int[,] solvePossibleNum(int[,] question)
        {
            int[,] result = (int[,])question.Clone();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (result[i, j] != 0)
                        continue;

                    ArrayList list = makeArrayList();

                    list = removeExitNum(list, getSelectedRow(i, question));
                    list = removeExitNum(list, getSelectedColumn(j, question));
                    list = removeExitNum(list, getSelected3x3Array(i / 3, j / 3, question));

                    if (list.Count == 1)
                    {
                        result[i, j] = (int)list[0];
                    }
                }
            }

            return result;
        }

        public bool isPossibleToSolve(int[,] question)
        {
            bool isListEmpty = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (question[i, j] != 0)
                        continue;

                    ArrayList list = makeArrayList();

                    list = removeExitNum(list, getSelectedRow(i, question));
                    list = removeExitNum(list, getSelectedColumn(j, question));
                    list = removeExitNum(list, getSelected3x3Array(i / 3, j / 3, question));

                    if (list.Count == 1)
                        return true;

                    if (list.Count > 1)
                        isListEmpty = true;

                }
            }

            return false;
        }

        public bool finalValidate(int[,] answer)
        {
            int i = 0, j = 0;

            //check all row and colum
            for(i = 0; i < 9; i++)
            {
                if (!checkOneRow(getSelectedRow(i, answer)) ||
                    !checkOneRow(getSelectedColumn(i, answer)))
                {
                    return false;
                }
            }

            for(i = 0; i < 3; i++)
            {
                for(j = 0; j < 3; j++)
                {
                    if (!checkOneRow(getSelected3x3Array(i, j, answer)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool validate(int[,] answer)
        {
            int i = 0, j = 0;

            //check all row and colum
            for (i = 0; i < 9; i++)
            {
                if (!checkOneRowWithoutZero(getSelectedRow(i, answer)) ||
                    !checkOneRowWithoutZero(getSelectedColumn(i, answer)))
                {
                    return false;
                }
            }

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (!checkOneRowWithoutZero(getSelected3x3Array(i, j, answer)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public ArrayList makeArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);
            arrayList.Add(6);
            arrayList.Add(7);
            arrayList.Add(8);
            arrayList.Add(9);
            return arrayList;
        }

        public int[] getSelectedRow(int rowIndex, int[,] array2D)
        {
            int[] resultArray = new int[9];

            for (int i = 0; i < 9; i++)
            {
                resultArray[i] = array2D[rowIndex, i];
            }

            return resultArray;
        }

        public int[] getSelectedColumn(int columnIndex, int[,] array2D)
        {
            int[] resultArray = new int[9];

            for (int i = 0; i < 9; i++)
            {
                resultArray[i] = array2D[i, columnIndex];
            }

            return resultArray;
        }

        public int[] getSelected3x3Array(int rowIndex, int colIndex, int[,] array2D)
        {
            int[] resultArray = new int[9];

            for (int i = 0; i < 3; i++)
            {
                resultArray[i*3] = array2D[rowIndex*3 + i, colIndex*3];
                resultArray[i*3 + 1] = array2D[rowIndex*3 + i, colIndex*3 + 1];
                resultArray[i*3 + 2] = array2D[rowIndex*3 + i, colIndex*3 + 2];
            }

            return resultArray;
        }

        public bool checkOneRow(int[] oneRaw)
        {
            ArrayList arrayList = makeArrayList();

            for (int i = 0; i < oneRaw.Length; i++)
            {
                if (oneRaw[i] == 0)
                    return false;

                arrayList.Remove(oneRaw[i]);
            }

            if (arrayList.Count == 0)
                return true;

            return false;
        }

        public bool checkOneRowWithoutZero(int[] oneRaw)
        {
            ArrayList arrayList = makeArrayList();

            for (int i = 0; i < oneRaw.Length; i++)
            {
                if (oneRaw[i] == 0)
                    continue;

                if (!arrayList.Contains(oneRaw[i]))
                    return false;

                arrayList.Remove(oneRaw[i]);
            }
            return true;
        }

        public ArrayList getNeedNumList(int[] selectedRow)
        {
            ArrayList list = makeArrayList();

            for (int i = 0; i < selectedRow.Length; i++)
            {
                list.Remove(selectedRow[i]);
            }

            return list;
        }

        public ArrayList removeExitNum(ArrayList list, int[] v)
        {
            ArrayList result = (ArrayList)list.Clone();

            for(int i = 0; i < v.Length; i++)
            {
                result.Remove(v[i]);
            }

            return result;
        }
    }
}