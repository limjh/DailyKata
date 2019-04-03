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
            return question;
        }

        public bool validate(int[,] answer)
        {
            return false;
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

        private ArrayList makeArrayList()
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

        public int[,] convertRowToCol(int[,] array2D)
        {

            int[,] result = new int[9, 9];

            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    result[i, j] = array2D[j, i];
                }
            }

            return result;
        }
    }
}