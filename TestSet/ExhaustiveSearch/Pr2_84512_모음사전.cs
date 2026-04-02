// https://school.programmers.co.kr/learn/courses/30/lessons/84512

// 문제 설명
// 사전에 알파벳 모음 'A', 'E', 'I', 'O', 'U'만을 사용하여 만들 수 있는, 길이 5 이하의 모든 단어가 수록되어 있습니다. 사전에서 첫 번째 단어는 "A"이고, 그다음은 "AA"이며, 마지막 단어는 "UUUUU"입니다.

// 단어 하나 word가 매개변수로 주어질 때, 이 단어가 사전에서 몇 번째 단어인지 return 하도록 solution 함수를 완성해주세요.

// 제한사항
// word의 길이는 1 이상 5 이하입니다.
// word는 알파벳 대문자 'A', 'E', 'I', 'O', 'U'로만 이루어져 있습니다.

// case 1.
// var word = "AAAAE";
// result 6

// case 2.
// var word = "AAAE";
// result 10

// case 3.
// var word = "I";
// result 1563

// case 4.
// var word = "EIO";
// result 1189

// 입출력 예 설명
// 입출력 예 #1

// 사전에서 첫 번째 단어는 "A"이고, 그다음은 "AA", "AAA", "AAAA", "AAAAA", "AAAAE", ... 와 같습니다. "AAAAE"는 사전에서 6번째 단어입니다.

// 입출력 예 #2

// "AAAE"는 "A", "AA", "AAA", "AAAA", "AAAAA", "AAAAE", "AAAAI", "AAAAO", "AAAAU"의 다음인 10번째 단어입니다.

// 입출력 예 #3

// "I"는 1563번째 단어입니다.

// 입출력 예 #4

// "EIO"는 1189번째 단어입니다.

// 📌 781이 나오는 과정 (가중치)
// 단어 길이는 1~5까지 가능하므로, 첫 번째 자리가 A일 때 뒤에 붙을 수 있는 경우들을 모두 합산합니다.
// - 길이 1: "A" → 1개
// - 길이 2: "AA", "AE", "AI", "AO", "AU" → 5개
// - 길이 3: "AAA", "AAE", ... "AUU" → 5 ^ 2 = 25개
// - 길이 4: "AAAA", ... "AUUU" → 5 ^ 3 = 125개
// - 길이 5: "AAAAA", ... "AUUUU" → 5 ^ 4 = 625개

// 모음 순서가 변환될 때 다음과 같이 증가
// 첫번째 글자가 E 라면 A로 만들 수 있는 모든 글자 다음에 오게 되므로,
// 1, 6, 31, 156, 781 순서로 증가
// 두번째 글자는 1, 5, 25, 125 의 순서로 증가
// 세번째 글자는 1, 5, 25 순서로 증가 (AAU 는 AAA, AAE, AAA~, AAE~, AAA~~, AAE~~, 로 만들 수 있는 글자 이후 순서)
// 네 번째 글자는 1, 5 순서로 증가 (AAAE 는 AAAA - AAAAA, AAAAE, AAAAI, AAAAO, AAAAU, AAAE -> 6번째)
// 다섯 번째 글자는 1의 순서로 증가 (다섯자리 글자라고 하면? AAAAA, AAAAE, AAAAI, AAAAO, AAAAU 순서이므로 알파벳 바뀔 때 마다 순서가 1씩 증가)

// 1. A
// 2. AA
// 3. AAA
// 4. AAAA
// 5. AAAAA
// 6. AAAAE
// 7. AAAAI
// 8. AAAAO
// 9. AAAAU
// 10. AAAE
// 11. AAAEA
// 12. AAAEE
// ...
// 156. AE (AA 로 시작하는 모든 단어가 오고 그 뒤에 "AE" 등장)


using System;
var sol = new Solution();
string word = "AAAEA";
Console.WriteLine(sol.solution(word));
public class Solution
{
    public int solution(string word)
    {
        // 모음 배열
        char[] vowels = { 'A', 'E', 'I', 'O', 'U' };

        // 각 자리별 가중치 (뒤에 붙을 수 있는 모든 경우의 수 + 자기 자신)
        int[] weights = { 781, 156, 31, 6, 1 };

        int index = 0;

        for (int i = 0; i < word.Length; i++)
        {
            // 현재 글자가 모음 배열에서 몇 번째인지 찾기
            int pos = Array.IndexOf(vowels, word[i]);

            // 해당 자리에서 점프할 수 있는 개수 = pos * weights[i]
            index += pos * weights[i];
        }

        // 자기 자신을 포함해야 하므로 + word.Length
        return index + word.Length;

    }
}