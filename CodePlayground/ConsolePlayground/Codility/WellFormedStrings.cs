using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.WellFormedStrings
{
    class Solution
    {
        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (string.IsNullOrEmpty(S))
            {
                return 1;
            }

            int depth = 0;
            
            foreach(char s in S)
            {
                if(s == '(')
                {
                    depth += 1;
                }
                if (s == ')')
                {

                    if(depth == 0)
                    {
                        return 0;
                    }

                    depth -= 1;
                }
            }

            return depth == 0 ? 1 : 0 ;
            
        }
    }
}
