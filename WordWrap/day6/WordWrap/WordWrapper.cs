using System;
using System.Collections;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string wrapping(string argStr, int argInt)
        {
            //String argStr = "a lot of words for a single line";
            //String expected = "a lot of--words for--a single--line";

            String result = "";

            ArrayList stringList = makeArrayList(argStr);

            int lintColCnt = 0;

            for(int arrayCnt = 0; arrayCnt < stringList.Count; arrayCnt++)
            {
                result += stringList[arrayCnt];

                if (result.Length < argInt)
                {

                }

                if (arrayCnt + 1 != stringList.Count)
                {
                    result += "--";
                }
            }

            return result;
        }

        public ArrayList makeArrayList(string argTest)
        {
            String[] tmpArray = argTest.Split('\x020');

            ArrayList arrayList = new ArrayList();

            for(int i = 0; i < tmpArray.Length; i++)
            {
                arrayList.Add(tmpArray[i]);
            }

            return arrayList;
        }
    }
}