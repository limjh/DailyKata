using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums) {
            TreeNode root = CreateNode(nums, 0, nums.Length - 1);
            return root;
        }
        
        public TreeNode CreateNode(int[] nums, int indexStart, int indexEnd)
        {
            if (indexStart > indexEnd)
                return null;

            int indexMaxNum = FindMaxNumIndex(nums, indexStart, indexEnd);
            TreeNode root = new TreeNode(nums[indexMaxNum]);

            root.left = CreateNode(nums, indexStart, indexMaxNum - 1);
            root.right = CreateNode(nums, indexMaxNum + 1, indexEnd);

            return root;

        }

        public int FindMaxNumIndex(int[] nums, int indexStart, int indexEnd)
        {
            int currentMax = 0;
            int indexMaxNum = 0;
            for (int i = indexStart; i <= indexEnd; i++)
            {
                if (nums[i] >= currentMax)
                {
                    currentMax = nums[i];
                    indexMaxNum = i;
                }
            }
            return indexMaxNum;
        }
    }
}
