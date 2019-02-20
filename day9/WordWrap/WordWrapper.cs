using System;
using System.Collections;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public ArrayList MakeArrayList(string arg)
        {
            String[] tmpArray = arg.Split('\x020');

            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < tmpArray.Length; i++)
            {
                arrayList.Add(tmpArray[i]);

                if (i != tmpArray.Length - 1)
                    arrayList.Add(" ");
            }

            return arrayList;
        }

        public string Wrapping(string argString, int argInt)
        {
            String result = "";

            ArrayList stringArray = MakeArrayList(argString);


            int addCount = 0;

            for(int i = 0; i < stringArray.Count; i++)
            {
                if (addCount + ((String)stringArray[i]).Length > argInt)
                {
                    if (((String)stringArray[i]).Length > argInt)
                    {
                        String tmpStrFront = "";
                        String tmpStrEnd = "";

                        int frontSize = argInt - addCount;
                        tmpStrFront = ((String)stringArray[i]).Substring(0, frontSize);
                        tmpStrEnd = ((String)stringArray[i]).Substring(frontSize, ((String)stringArray[i]).Length - frontSize);

                        stringArray.RemoveAt(i); 
                        stringArray.Insert(i, tmpStrFront);
                        stringArray.Insert(i + 1, " ");
                        stringArray.Insert(i + 2, tmpStrEnd);

                        i--;
                        addCount = 0;

                        continue;
                    }

                    if (((String)stringArray[i - 1]) == " ")
                        result = result.Substring(0, result.Length - 1);
                    
                    result += "--";
                    i--;
                    addCount = 0;
                    continue;
                }

                if (addCount == 0 && ((String)stringArray[i]) == " ")
                    continue;

                result += stringArray[i];
                addCount += ((String)stringArray[i]).Length;
            }


            return result;
        }
    }
}