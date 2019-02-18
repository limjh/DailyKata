using System;
using System.Collections;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public ArrayList MakeArrayList(String arg)
        {
            String[] tmpArray = arg.Split('\x020');

            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < tmpArray.Length; i++)
            {
                arrayList.Add(tmpArray[i]);
            }

            return arrayList;
        }

        public string Wrapping(string argString, int argInt)
        {
            // hello world >> hello--world
            //a lot of words for a single line >> a lot of--words for--a single--line

            ArrayList arrayList = MakeArrayList(argString);
            String resultString = "";
            String tmpString = "";

            for (int i = 0; i < arrayList.Count; i++)
            {
                String str = "";
                str += arrayList[i];
                if (tmpString.Length + str.Length >= argInt)
                {
                    resultString += "--";
                    tmpString = "";
                } 


                resultString += arrayList[i];
                tmpString += arrayList[i];

                if (i < arrayList.Count - 1)
                {
                    resultString += " ";
                    tmpString += " ";
                }

            }

            return resultString;
        }
    }
}