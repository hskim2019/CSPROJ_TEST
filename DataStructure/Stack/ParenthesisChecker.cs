// https://www.geeksforgeeks.org/problems/parenthesis-checker2744/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
namespace DotNet.DataStructure.Stack
{
    public class ParenthesisChecker 
    {
        public ParenthesisChecker() {

        }

        public void Test() {
            //Your code here
        Stack<char> s = new Stack<char>();
        string x = "[])";
        char[] exp = x.ToCharArray();
            char[] startBrace = { '[', '{', '(' };
            char[] endBrace = { ']', '}', ')' };
            Dictionary<char, char> dicBrace = new Dictionary<char, char>();
            dicBrace.Add(']', '[');
            dicBrace.Add('}', '{');
            dicBrace.Add(')', '(');
            
            bool balanced = true;
            
            foreach(char c in exp) {
                
              if(startBrace.Contains(c)) {
                s.Push(c);
              } 

              if(endBrace.Contains(c)) {
                if(s.Count() > 0) {
                    if(s.Peek() == dicBrace[c]) {
                        s.Pop();
                    } else {
                        s.Push(c);
                    }
                } else {
                    s.Push(c);
                }
              }
             }
            
            if(s.Count() > 0) {
                balanced = false;
            }

            Console.WriteLine("result : {0}", balanced.ToString());
        }
    }
}