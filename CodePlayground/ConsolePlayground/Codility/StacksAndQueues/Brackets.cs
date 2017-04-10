using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.StacksAndQueues
{

    /*
     * A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:

        S is empty;
        S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;
        S has the form "VW" where V and W are properly nested strings.
        For example, the string "{[()()]}" is properly nested but "([)()]" is not.

        Write a function:

        class Solution { public int solution(string S); }

        that, given a string S consisting of N characters, returns 1 if S is properly nested and 0 otherwise.

        For example, given S = "{[()()]}", the function should return 1 and given S = "([)()]", the function should return 0, as explained above.

        Assume that:

        N is an integer within the range [0..200,000];
        string S consists only of the following characters: "(", "{", "[", "]", "}" and/or ")".
        Complexity:

        expected worst-case time complexity is O(N);
        expected worst-case space complexity is O(N) (not counting the storage required for input arguments).
        Copyright 2009–2017 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
        */

    class Brackets
    {

        private bool IsOpen(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            Stack<char> stack = new Stack<char>();

            for(int i = 0; i<S.Length; i++)
            {
                char c = S[i];

                if(c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        return 0;
                    }
                    char popped = stack.Pop();

                    if (c == '}' && popped != '{') return 0;
                    if (c == ')' && popped != '(') return 0;
                    if (c == ']' && popped != '[') return 0;

                }

            }

            return stack.Count == 0 ? 1 : 0;
            
        }

    }

    public class BracketsTests
    {
        Brackets _sut = new Brackets();

        [Test]
        public void BracketsTest()
        {
            Assert.AreEqual(1, _sut.solution("{[()()]}"));
            Assert.AreEqual(0, _sut.solution("{{{{"));
        }
    }


}
