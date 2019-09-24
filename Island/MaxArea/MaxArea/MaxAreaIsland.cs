using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxArea
{
    public class ItemInfo
    {
        public bool isLeft = false;
        public bool isRight = false;
        public bool isTop = false;
        public bool isBottom = false;
    }

    public class MaxAreaIsland
    {
        public int getMaxAreaSize(int[,] input)
        {
            int result = 0;

            int row = input.GetLength(0);
            int col = input.GetLength(1);

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] != 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public bool checkPossibleDirection(int[,] input, int rowIndex, int colmIndex, out ItemInfo info)
        {
            ItemInfo newInfo = new ItemInfo();

            // check left
            if (colmIndex != 0)
                newInfo.isLeft = input[rowIndex, colmIndex - 1] == 0 ? false : true; 


            // check right
            if (colmIndex + 1 != input.GetLength(1))
                newInfo.isRight = input[rowIndex, colmIndex + 1] == 0 ? false : true;

            // check top
            if (rowIndex != 0)
                newInfo.isTop = input[rowIndex - 1, colmIndex] == 0 ? false : true;

            // check bottom
            if (rowIndex + 1 != input.GetLength(0))
                newInfo.isBottom = input[rowIndex + 1, colmIndex] == 0 ? false : true;

            info = newInfo;

            return info.isLeft | info.isRight | info.isTop | info.isBottom;
        }
    }
}
