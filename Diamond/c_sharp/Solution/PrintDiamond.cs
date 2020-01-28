using System;   
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class PrintDiamond
    {
        private int SPACE = 100;
        string[] alphabetArray = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        ArrayList alphabetArrayList = new ArrayList();

        public PrintDiamond()
        {
            alphabetArrayList.Add("A");
            alphabetArrayList.Add("B");
            alphabetArrayList.Add("C");
            alphabetArrayList.Add("D");
            alphabetArrayList.Add("E");
            alphabetArrayList.Add("F");
            alphabetArrayList.Add("G");
            alphabetArrayList.Add("H");
            alphabetArrayList.Add("I");
            alphabetArrayList.Add("J");
            alphabetArrayList.Add("K");
            alphabetArrayList.Add("L");
            alphabetArrayList.Add("M");
            alphabetArrayList.Add("N");
            alphabetArrayList.Add("O");
            alphabetArrayList.Add("P");
            alphabetArrayList.Add("Q");
            alphabetArrayList.Add("R");
            alphabetArrayList.Add("S");
            alphabetArrayList.Add("T");
            alphabetArrayList.Add("U");
            alphabetArrayList.Add("V");
            alphabetArrayList.Add("W");
            alphabetArrayList.Add("X");
            alphabetArrayList.Add("Y");
            alphabetArrayList.Add("Z");
        }

        public List<ArrayList> print(string v)
        {
            List<ArrayList> noteBook = new List<ArrayList>();

            if (!isAlphaalphabet(v))
                return noteBook;


            int rowColSize = getRowColSize(v);
            int rowIndex = 0;
            int colIndex = 0;
            int rowDistance = 0;
            int colDistance = 1;

            for (int i = 0; i < rowColSize; i++)
            {
                rowDistance = -1;
                rowIndex = getAlphabetIndex(v);

                ArrayList row = new ArrayList();
                
                for (int j = 0; j < rowColSize; j++)
                {
                    if (rowIndex == colIndex)
                        row.Add(rowIndex);
                    else
                        row.Add(SPACE);

                    if (rowIndex == 0)
                        rowDistance *= -1;

                    rowIndex += rowDistance;
                }

                if (colIndex == getAlphabetIndex(v))
                    colDistance *= -1;

                colIndex += colDistance;

                noteBook.Add(row);
            }

            // --A--   21012
            // -B-B-
            // C---C   21012
            // -B-B-
            // --A--

            for (int i = 0; i < noteBook.Count; i++)
            { 
                for (int j = 0; j < noteBook[i].Count; j++)
                {
                    if ((int)noteBook[i][j] != SPACE)
                        noteBook[i][j] = alphabetArray[(int)noteBook[i][j]];
                    else
                        noteBook[i][j] = "-";
                }
            }
            
            return noteBook;
        }

        private bool isAlphaalphabet(string v)
        {
            return char.IsLetter(v.ToCharArray()[0]);
        }

        private int getIndexOfAlphabet(string alphabet)
        {
            return alphabetArrayList.IndexOf(alphabet);
        }

        private int getRowColSize(string alphabet)
        {
            return alphabetArrayList.IndexOf(alphabet) * 2 + 1;
        }

        private int getAlphabetIndex(string alphabet)
        {
            return alphabetArrayList.IndexOf(alphabet);
        }

    }
}
