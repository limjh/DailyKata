using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareVersionNumber
{
    public class CompareVersionClass
    {

        public int CompareVersion(string version1, string version2)
        {
            int[] version1IntArray = StringArraytoIntArray(Spliter(version1));
            int[] version2IntArray = StringArraytoIntArray(Spliter(version2));

            for(int i = 0; i < version1IntArray.Length; i++)
            {
                if (version1IntArray[i] > version2IntArray[i])
                {
                    return 1;
                }
                else if (version1IntArray[i] == version2IntArray[i])
                {
                    continue;
                }
                else
                {
                    return -1;
                }
            }

            return 0;
        }

        public string[] Spliter(string input)
        {
            string[] result = { "0", "0", "0", "0" };

            string[] splited = input.Split('.');

            for (int i = 0; i < splited.Length && i < 4; i++)
            {
                result[i] = splited[i];
            }

            return result;
        }

        public int[] StringArraytoIntArray(string[] input)
        {
            int[] result = { 0, 0, 0, 0 };

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = int.Parse(input[i]);
            }

            return result;
        }
    }
}
