using System;
using System.Collections;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public ArrayList makeStringArrayList(string arg)
        {
            ArrayList list = new ArrayList();

            String[] stringArray = arg.Split('\x020');

            for (int i = 0 ; i < stringArray.Length; i++)
            {
                list.Add(stringArray[i]);
            }

            return list;
        }
    }
}