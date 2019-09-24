using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareVersionNumber
{
    public class CompareVersionClass
    {

        public int CompareVersion3(string version1, string version2)
        {
            var replacedZero1 = replaceFrontZero(version1);
            var replacedZero2 = replaceFrontZero(version2);

            var replaced1 = replacedZero1.Replace(".", "");
            var replaced2 = replacedZero2.Replace(".", "");

            var num1 = int.Parse(replaced1);
            var num2 = int.Parse(replaced2);

            var len1 = replaced1.Length;
            var len2 = replaced2.Length;

            var backDiff = Math.Abs(len1 - len2);

            var frontZero1 = 0;
            for (int i = 0; i < replaced1.Length; i++)
            {
                if (i == replaced1.IndexOf('0', i))
                {
                    frontZero1++;
                }
                else
                {
                    break;
                }
            }

            var frontZero2 = 0;
            for (int i = 0; i < replaced2.Length; i++)
            {
                if (i == replaced2.IndexOf('0', i))
                {
                    frontZero2++;
                } else
                {
                    break;
                }
            }

            if (len1 > len2)
            {
                num2 *= (int)Math.Pow(10, (double)backDiff);
            }
            else if (len1 < len2)
            {
                num1 *= (int)Math.Pow(10, (double)backDiff);
            }

            if (frontZero1 > 0) num2 *= 10 * frontZero1;
            if (frontZero2 > 0) num1 *= 10 * frontZero2;


            if (num1 == num2) return 0;

            return num1 > num2 ? 1 : -1;
        }

        public string replaceFrontZero(string input)
        {
            while (input.Contains(".0"))
            {
                input = input.Replace(".0", ".");
            }

            return input;
        }

        public int CompareVersion2(string version1, string version2)
        {
            var splited1 = version1.Split('.');
            var splited2 = version2.Split('.');

            var maxLen = splited1.Length >= splited2.Length ? splited1.Length : splited2.Length;

            for(int i = 0; i < maxLen; i++)
            {
                var num1 = i >= splited1.Length ? 0 : int.Parse(splited1[i]);
                var num2 = i >= splited2.Length ? 0 : int.Parse(splited2[i]);

                if (num1 == num2) continue;

                return num1 > num2 ? 1 : -1;
            }
            return 0;
        }

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
