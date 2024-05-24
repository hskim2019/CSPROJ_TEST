//https://www.geeksforgeeks.org/problems/evaluation-of-postfix-expression1735/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
namespace DotNet.DataStructure.Stack
{
    public class EvaluationOfPostfixExpression
    {
        public EvaluationOfPostfixExpression () {

        }

        public void Test() {
            Stack<int> s = new Stack<int>();
            string S = "231*+9-";

            for(var i = 0; i < S.Length; i++) {
                if(char.IsDigit (S[i])) {
                    int tempNum = (int)S[i] - '0';   
                    s.Push (tempNum);                
                } else {
                    int num1 = s.Pop();
                    int num2 = s.Pop();
                    //Console.WriteLine("S[i] :" + S[i] + " num1 : " + num1 + " num2 :" + num2);
                    if(S[i] == '+') {
                        s.Push(num2 + num1);
                        Console.WriteLine("+");
                    } else if(S[i] == '-') {
                        s.Push(num2 - num1);
                        Console.WriteLine("-");
                    } else if(S[i] == '*') {
                        s.Push(num2 * num1);
                        Console.WriteLine("*");
                    } else if(S[i] == '/') {
                        s.Push(num2 / num1);
                        Console.WriteLine("/");
                    }
                }
                
            }
            var returnVal = s.Pop();
            Console.WriteLine(returnVal);
        }
    }
}