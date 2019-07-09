using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate
{
    class Rotater
    {
        public void Rotate(int[][] matrix)
        {
            int startX = 0;
            int startY = 0;

            int endPointX = GetEndPoint(matrix);

            while ()
            {
                
            }
        }

        public int GetEndPoint(int[][] matrix)
        {
            // check start point, if all rotated >> break
            double rowLength = Math.Sqrt((double)matrix.Length);
            if (rowLength % 2 == 0)
            {
                return (int)rowLength / 2 + 1;
            }
            else
            {
                return (int)rowLength / 2;
            }
        }
    }
}
