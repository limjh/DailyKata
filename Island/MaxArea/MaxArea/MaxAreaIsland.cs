using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
{0,1,0}
{1,1,1}
{0,1,0}

make itemConditionMap

000  | 011B     | 020
100R | 111LRTB  | 121L
200  | 211T     | 220

00 : SKIP(0)

01 : ADD, delete (first add. no check from), delete (to B), check, jump (B)

11 : ADD, delete (from T), delete (to L), check, jump (L)

10 : ADD, delete (from R), check no jump site >

check list's item(01, 11, 10) have LRTB > 11 Have R, B > delete (to R)

12 : ADD, delete (from L), check no jump site >

check list's item(01, 10, 11, 12) have LRTB > 11 Have B > delete (to B)

21 : ADD, delete(T), check no jump site > list clean > break;

01 : SKIP(isChecked)

02 : SKIP(0)

10 : SKIP(isChecked)

11 : SKIP(isChecked)
...
...
     */

namespace MaxArea
{
    public class ItemConditionInfo
    {
        /*
         * index- mean
        0       - rowIndex (int) 
        1       - colIndex (int) 
        2       - value (int)
        3       - isChecked(bool)
        4       - value of 1 on the left (string L)
        4|5     - value of 1 on the right (string R)
        4|5|6   - value of 1 on the top (string T)
        4|5|6|7 - value of 1 on the bottom (string B)
        */

        public ArrayList info = new ArrayList();

        public void SetIndexInfo(int rowIndex, int colmnIndex, int value)
        {
            bool isChecked = false;
            info.Add(rowIndex);
            info.Add(colmnIndex);
            info.Add(value);
            info.Add(isChecked);
        }
        public void SetItemIsChecked()
        {
            info.Remove(false);
            info.Insert(3, true);
        }
        public void SetAroundItemExist(bool left, bool right, bool top, bool bottom)
        {
            if (left)   info.Add("L");
            if (right)  info.Add("R");
            if (top)    info.Add("T");
            if (bottom) info.Add("B");
        }
        public int getRowIndex()
        {
            if (info.Count < 1)
                return -1;

            return (int)info[0];
        }

        public int getColIndex()
        {
            if (info.Count < 2)
                return -1;

            return (int)info[1];
        }

        public int getValue()
        {
            if (info.Count < 3)
                return -1;

            return (int)info[2];
        }
        public bool isChecked()
        {
            return (bool)info[3];
        }

        public bool isExistArroundIsland()
        {
            if (info.Contains("L") || 
                info.Contains("R") || 
                info.Contains("T") || 
                info.Contains("B"))
                return true;

            return false;
        }

        public bool isExistLeftIsland()
        {
            if (info.Contains("L"))
                return true;

            return false;
        }
        public bool isExistRightIsland()
        {
            if (info.Contains("R"))
                return true;

            return false;
        }
        public bool isExistTopIsland()
        {
            if (info.Contains("T"))
                return true;

            return false;
        }
        public bool isExistBottomIsland()
        {
            if (info.Contains("B"))
                return true;

            return false;
        }

        public void DeleteLeft()
        {
            info.Remove("L");
        }

        public void DeleteRight()
        {
            info.Remove("R");
        }

        public void DeleteTop()
        {
            info.Remove("T");
        }

        public void DeleteBottom()
        {
            info.Remove("B");
        }

        public void DeleteFrom(string from)
        {
            info.Remove(from);
        }
    }

    public class MaxAreaIsland
    {
        public void CreateConditionMap(int[][] input, out ItemConditionInfo[,] map)
        {
            int row = input.GetLength(0);
            int col = input[0].GetLength(0);

            map = new ItemConditionInfo[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    map[i, j] = new ItemConditionInfo();

                    map[i, j].SetIndexInfo(i, j, input[i][j]);

                    if ((int)map[i, j].info[2] == 0)
                    {
                        map[i, j].SetAroundItemExist(false, false, false, false);
                        continue;
                    }

                    bool isLeft = false;
                    bool isRight = false;
                    bool isTop = false;
                    bool isBottom = false;

                    if (j != 0)
                        isLeft = input[i][j - 1] == 0 ? false : true;
                    // check right
                    if (j + 1 != col)
                        isRight = input[i][j + 1] == 0 ? false : true;
                    // check top
                    if (i != 0)
                        isTop = input[i - 1][j] == 0 ? false : true;
                    // check bottom
                    if (i + 1 != row)
                        isBottom = input[i + 1][j] == 0 ? false : true;

                    map[i, j].SetAroundItemExist(isLeft, isRight, isTop, isBottom);
                }
            }

        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxSize = 0;
            ItemConditionInfo[,] map;

            CreateConditionMap(grid, out map);

            List<ItemConditionInfo> island = new List<ItemConditionInfo>();

            for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < grid[0].GetLength(0); colIndex++)
                {
                    island = TrakingIsland(ref map, rowIndex, colIndex);
                    if (maxSize < island.Count)
                        maxSize = island.Count;
                }
            }

            return maxSize;
        }

        public List<ItemConditionInfo> TrakingIsland(ref ItemConditionInfo[,] map, int indexRow, int indexCol)
        {
            List<ItemConditionInfo> result = new List<ItemConditionInfo>();

            if (map[indexRow, indexCol].isChecked())
                return result;

            if (!map[indexRow, indexCol].isExistArroundIsland() && map[indexRow, indexCol].getValue() == 0)
                return result;

            int currentRow = indexRow;
            int currentCol = indexCol;

            string from = "";

            while (true)
            {
                // delete from
                map[currentRow, currentCol].DeleteFrom(from);

                if (!map[currentRow, currentCol].isChecked())
                    result.Add(map[currentRow, currentCol]);

                map[currentRow, currentCol].SetItemIsChecked();

                from = "";

                // delete to & update site index
                // add list & continue
                if (map[currentRow, currentCol].isExistLeftIsland())
                {
                    map[currentRow, currentCol].DeleteLeft();

                    // goto Left
                    if (!map[currentRow, currentCol - 1].isChecked())
                    {
                        from = "R";
                        currentCol -= 1;
                    }
                    continue;
                }
                if (map[currentRow, currentCol].isExistRightIsland())
                {
                    map[currentRow, currentCol].DeleteRight();
                    
                    // goto Right
                    if (!map[currentRow, currentCol + 1].isChecked())
                    {
                        currentCol += 1;
                        from = "L";
                    }
                    continue;
                }
                if (map[currentRow, currentCol].isExistTopIsland())
                {
                    map[currentRow, currentCol].DeleteTop();
                    
                    // goto Top
                    if (!map[currentRow - 1, currentCol].isChecked())
                    {
                        currentRow -= 1;
                        from = "B";
                    }
                    continue;
                }
                if (map[currentRow, currentCol].isExistBottomIsland())
                {
                    map[currentRow, currentCol].DeleteBottom();
                    
                    //goto Bottom
                    if (!map[currentRow + 1, currentCol].isChecked())
                    {
                        from = "T";
                        currentRow += 1;
                    }
                    continue;
                }



                // check list item have LRTB & continue;
                bool remain = false;
                foreach (ItemConditionInfo element in result)
                {
                    if (element.isExistArroundIsland())
                    {
                        currentRow = element.getRowIndex();
                        currentCol = element.getColIndex();

                        while (true)
                        {
                            if (element.isExistLeftIsland())
                            {
                                element.DeleteLeft();
                                from = "R";
                                if (!map[currentRow, currentCol - 1].isChecked())
                                {
                                    currentCol -= 1;
                                    remain = true;
                                    break;
                                }
                            }
                            if (element.isExistRightIsland())
                            {
                                element.DeleteRight();
                                from = "L";
                                if (!map[currentRow, currentCol + 1].isChecked())
                                {
                                    currentCol += 1;
                                    remain = true;
                                    break;
                                }
                            }
                            if (element.isExistTopIsland())
                            {
                                element.DeleteTop();
                                from = "B";
                                if (!map[currentRow - 1, currentCol].isChecked())
                                {
                                    currentRow -= 1;
                                    remain = true;
                                    break;
                                }
                            }
                            if (element.isExistBottomIsland())
                            {
                                element.DeleteBottom();
                                from = "T";
                                if (!map[currentRow + 1, currentCol].isChecked())
                                {
                                    currentRow += 1;
                                    remain = true;
                                    break;
                                }
                            }
                            break;
                        }
                        if (remain)
                            break;
                    }
                }
                if (remain)
                    continue;

                break;
            }

            return result;
        }
    }
}