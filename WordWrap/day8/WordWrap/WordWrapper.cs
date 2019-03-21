using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public char[] MakeStringArray(string arg)
        {
            return arg.ToCharArray();
        }

        public string Wrapping(string argString, int colmLimit)
        {
            String result = "";
            char[] charArray = MakeStringArray(argString);

            int arrayCount = 0;

            while(arrayCount < charArray.Length)
            {
                if (arrayCount != 0)
                    result += "--";

                for (int i = 0; i < colmLimit; i++)
                {
                    if (arrayCount >= charArray.Length)
                        break;

                    

                    if (charArray[i] == ' ')
                    {
                        int tmpCount = i;
                        int nextWordLength = 0;

                        while (true)
                        {
                            tmpCount++;
                            if (tmpCount >= charArray.Length)
                                break;

                            if (charArray[tmpCount] == ' ')
                                break;

                            nextWordLength++;
                        }

                        if (nextWordLength + i > colmLimit)
                           
                    }

                    result += charArray[i];

                    arrayCount++;
                }
            }

            return result;
        }
    }
}