// https://school.programmers.co.kr/learn/courses/30/lessons/42578?language=csharp

using System;
using System.Collections.Generic;

namespace DotNet.TestSet
{
    public class Pr_Hash_42578
    {
        public void test()
        {
            // 선언
            string[,] testCase;

            // 나중에 초기화
            testCase = new string[,]
            {
                { "hat", "headgear" },
                { "sunglass", "eyewear" },
            };
            Console.Write(solution(testCase));
        }

        public int solution(string[,] clothes)
        {
            int answer = 1;

            // Hash Table 은 Generic 을 사용하지 않고 Object 를 사용하기 때문에 모든 데이터 타입을 처리할 수 있지만
            // 자료의 입력 시 내부에서 박싱, 자료 사용 시 언박싱 되어야 하므로
            // 미리 타입을 선언할 수 있고 박싱, 언박싱이 없는 딕셔너리 사용
            Dictionary<string, int> clothesCnt = new Dictionary<string, int>();

            for (int i = 0; i < clothes.GetLength(0); i++)
            {
                string type = clothes[i, 1];
                if (clothesCnt.ContainsKey(type))
                {
                    clothesCnt[type]++;
                }
                else
                {
                    clothesCnt[type] = 1;
                }
            }

            foreach (var count in clothesCnt.Values)
            {
                answer *= (count + 1);
            }

            answer--; // 의상을 입지 않은 경우 제외
            return answer;
        }
    }
}
