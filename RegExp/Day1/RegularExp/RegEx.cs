using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;



public enum ErrorCodes : uint
{
    ERROR_MATCHING_FAIL     = 0x01,
    ERROR_INVALID_INPUT     = 0x02,
    ERROR_INVALID_PATTERN   = 0x03,

    ERROR_MATCHING_SUCCESS = 0x00,
}

namespace RegularExp
{
    public class Solution
    {
        //public ErrorCodes matching(string input, string pattern)
        public bool IsMatch(string s, string p)
        {
            if (!isValidInput(s))
            {
                //return ErrorCodes.ERROR_INVALID_INPUT;
                return false;
            }

            if (!isValidPattern(p))
            {
                //return ErrorCodes.ERROR_INVALID_PATTERN;
                return false;
            }

            ArrayList inputArrayList = stringToArrayList(s);
            ArrayList patternArrayList = stringToArrayList(p);

            // EX1 : 패턴 문자열에 *가 포함되지 않을경우 입력 문자열의 길이는 패턴 문자열의 길이보다 클수 없다
            if (!isContainStar(patternArrayList) &&
                s.Length != p.Length) {
                return false;
            }

            // EX2 : 
            int indexPattern = 0;
            int indexPatternSub = 0;
            int indexInput = 0;
            while(indexPattern < p.Length)
            {
                indexPatternSub = indexPattern;

                bool isCatch = true;

                for(indexInput = 0; indexInput < s.Length; indexInput++)
                {
                    if (isMatchOneLetter((string)patternArrayList[indexPatternSub], (string)inputArrayList[indexInput]))
                    {
                        // same letter
                        indexPatternSub++;
                        if (indexPatternSub >= p.Length)
                            break;

                        continue;
                    }


                    // does not same
                    if (isMatchOneLetter((string)patternArrayList[indexPatternSub], "*") &&
                        indexPatternSub > 0)
                    {
                        // check pre-pattern
                        if (isMatchOneLetter((string)patternArrayList[indexPatternSub - 1], (string)inputArrayList[indexInput]) ||
                            ((indexPatternSub + 1 < p.Length - 1) &&
                            (isMatchOneLetter((string)patternArrayList[indexPatternSub + 1], (string)inputArrayList[indexInput]))))
                        {
                            // same letter
                            indexPatternSub++;

                            if (indexPatternSub >= p.Length &&
                                indexInput < (s.Length - 1))
                            {
                                indexPatternSub--;
                                continue;
                            }


                            if (indexPatternSub >= p.Length)
                                break;

                            continue;
                        }
                    }

                    // 현재 문자가 같지않고 다음 문자열이 * 일경우 현재 문자 생략 가능 
                    if (indexPatternSub + 2 < p.Length &&
                        indexInput != 0 &&
                        isMatchOneLetter((string)patternArrayList[indexPatternSub + 1], "*"))
                    {

                        indexPatternSub += 2;
                        indexInput -= 1;
                        continue;
                    }

                    // check next patter letter
                    isCatch = false;
                    break;
                }

                if (isCatch && indexInput == (s.Length - 1)) {
                    //return ErrorCodes.ERROR_MATCHING_SUCCESS;
                    return true;
                }



                indexPattern++;
            }

            //return ErrorCodes.ERROR_MATCHING_FAIL;
            return false;
        }

        public bool isMatchOneLetter(string input1, string input2)
        {
            if (input1.Contains(input2) || input2.Contains(input1))
            {
                return true;
            }

            if (input1.Contains(".") || input2.Contains("."))
            {
                return true;
            }

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

        public bool isValidInput(string input)
        {
            Regex regex = new Regex(@"[A-Za-z]");
            MatchCollection matches = regex.Matches(input);

            if (matches.Count != input.Length)
                return false;

            return true;
        }

        public bool isValidPattern(string pattern)
        {
            Regex regex = new Regex(@"[A-Za-z.\*]");
            MatchCollection matches = regex.Matches(pattern);

            if (matches.Count != pattern.Length)
                return false;

            return true;
        }

        public bool isContainStar(ArrayList pattern)
        {
            foreach (string c in pattern)
            {
                if (c.Contains("*"))
                    return true;
            }
            return false;
        }

        public bool isContainComma(ArrayList pattern)
        {
            foreach (string c in pattern)
            {
                if (c.Contains("."))
                    return true;
            }
            return false;
        }
    }
}
