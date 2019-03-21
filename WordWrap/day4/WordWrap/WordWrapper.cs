using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string wrapping(string arg1, int arg2)
        {

            String result = arg1.Replace(" ", "--");

            return result;
        }
    }
}