﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public enum ErrorCodes : uint
{
    ERROR_MATCHING_FAIL     = 0x01,
    ERROR_INVALID_INPUT     = 0x02,
    ERROR_INVALID_PATTERN   = 0x03,

    ERROR_MATCHING_SUCCESS = 0x00,
}

namespace RegularExp
{
    public class RegEx
    {
        public ErrorCodes matching(string input, string pattern)
        {
            if (!isValidInput(input))
                return ErrorCodes.ERROR_INVALID_INPUT;

            if (!isValidPattern(pattern))
                return ErrorCodes.ERROR_INVALID_PATTERN;

            ArrayList inputArrayList = stringToArrayList(input);
            ArrayList patternArrayList = stringToArrayList(pattern);

            // EX1 : 패턴 문자열에 *가 포함되지 않을경우 입력 문자열의 길이는 패턴 문자열의 길이보다 클수 없다
            if (!isContainStar(patternArrayList) &&
                input.Length > pattern.Length)
                return ErrorCodes.ERROR_MATCHING_FAIL;

            // EX2 : 
            int indexPattern = 0;
            int indexPatternSub = 0;
            while(indexPattern < pattern.Length)
            {
                indexPatternSub = indexPattern;

                bool isCatch = true;

                for(int i = 0; i < input.Length; i++)
                {
                    if ( ((string)patternArrayList[indexPatternSub]).CompareTo((string)inputArrayList[i]) == 0 )
                    {
                        // same letter
                        if ((indexPatternSub + 1) >= pattern.Length) {
                            isCatch = false;
                            break;
                        }
                        indexPatternSub++;

                        continue;
                    }

                    // does not same
                    if ( ((string)patternArrayList[indexPatternSub]).CompareTo("*") == 0  &&
                        indexPatternSub > 0)
                    {
                        // check pre-pattern
                        if (((string)patternArrayList[indexPatternSub - 1]).CompareTo((string)inputArrayList[i]) == 0)
                        {
                            // same letter
                            if ((indexPatternSub + 1) >= pattern.Length)
                            {
                                isCatch = false;
                                break;
                            }
                            indexPatternSub++;

                            continue;
                        }
                    }

                    // check next patter letter
                    isCatch = false;
                    break;
                }

                if (isCatch)
                    return ErrorCodes.ERROR_MATCHING_SUCCESS;

                indexPattern++;
            }

            return ErrorCodes.ERROR_MATCHING_SUCCESS;
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
    }
}