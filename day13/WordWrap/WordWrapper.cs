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

                //if (i != tmpArray.Length - 1)
                //    arrayList.Add(" ");
            }

            return arrayList;
        }

        public string Wrapping(string argString, int colLen)
        {
            String result = "";
            int addCount = 0;

            ArrayList arrayList = MakeArrayList(argString);

            for (int i = 0; i < arrayList.Count; i++)
            {
                // 누적된 라인 글자수와 다음 문자열의 글자수 합이 라인 한계치를 초과할 경우 (조건에 맞추어 -- 문자열을 추가해야한다)
                if (addCount + ((String)arrayList[i]).Length > colLen)
                {
                    // 다음 문자열이 라인 한계치를 초과할 경우
                    // 문자열을 쪼개어 다시 arraylist 에 추가한다.
                    // 첫번째 문자열은 (라인 한계치 - 누적된 라인 글자수) 만큼 설정한다.
                    // 두번째 문자열은 나머지 글자를 모두 포함하게 한다.
                    // 첫번째 두번째 문자열 사이에는 공백을 추가한다.
                    if (((String)arrayList[i]).Length > colLen)
                    {
                        String tmpStrFront = "";
                        String tmpStrEnd = "";

                        if (result.Length != 0 && result.Substring(result.Length - 1) == " ")
                            addCount--;

                        int frontSize = colLen - addCount;
                        tmpStrFront = ((String)arrayList[i]).Substring(0, frontSize);
                        tmpStrEnd = ((String)arrayList[i]).Substring(frontSize, ((String)arrayList[i]).Length - frontSize);

                        arrayList.RemoveAt(i);
                        arrayList.Insert(i, tmpStrFront);
                        //arrayList.Insert(i + 1, " ");
                        arrayList.Insert(i + 1, tmpStrEnd);

                        i--;
                        addCount = 0;

                        continue;
                    }

                    // -- 문자열을 추가하기전 마지막 문자가 공백이면 제거
                    //if (((String)arrayList[i - 1]) == " ")
                    if (result.Substring(result.Length - 1) == " ")
                        result = result.Substring(0, result.Length - 1);

                    // -- 문자열 추가
                    result += "--";
                    // 실제 array 내용이 추가및 생략되지 않았으므로 
                    i--;
                    // 누적된 라인내 글자수 초기화
                    addCount = 0;
                    continue;
                }

                //// 추가할 문자열의 라인의 첫번째 문자이면서 공백일 경우 생략한다.
                //if (addCount == 0 && ((String)arrayList[i]) == " ")
                //    continue;

                // 문자열 추가 및 누적된 라인 글자수 업데이트
                result += arrayList[i] + " ";
                addCount += ((String)arrayList[i]).Length + 1;
            }

            //return result;
            return result.Substring(0, result.Length - 1);
        }
    }
}