using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExp
{
    public class RegEx
    {
        public bool matching(string input, string pattern)
        {
            ArrayList inputArrayList = stringToArrayList(input);
            ArrayList patternArrayList = stringToArrayList(pattern);

            


            return false;
        }

        public ArrayList stringToArrayList(string input)
        {
            ArrayList output = new ArrayList();

            List<Char> list = input.ToList();
            foreach(Char s in list)
            {
                output.Add(s.ToString());
            }

            return output;
        }

        public bool isContainStar(ArrayList list)
        {
            foreach (string c in list)
            {
                if (c.Contains("*"))
                    return true;
            }
            return false;
        }
    }
}
