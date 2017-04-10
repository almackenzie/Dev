using System;
// you can also use other imports, for example:
using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");
namespace ConsolePlayground.Codility.StacksAndQueues
{


    class Solution
    {
        public int solution(int[] H)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            Stack<int> stack = new Stack<int>();
            int count = 0;
            foreach (int i in H)
            {
                int current = stack.Count == 0 ? 0 : stack.Peek();
                if (i > current)
                {
                    count++;
                    //stack.Push(current);
                    stack.Push(i);
                }
                else if (i < current)
                {
                    // keep popping until i >= current
                    do
                    {
                        stack.Pop();
                        current = stack.Count == 0 ? 0 : stack.Peek();
                    } while (i < current && stack.Count > 0);

                    if (current == i)
                    {
                        // carry on - no need for a new block
                        //stack.Push(current);
                    }
                    else
                    {
                        count++;
                        stack.Push(i);
                    }
                }
                else
                {
                    // ok - so the height has not changed, so carry on
                    //stack.Push(current);
                }


            }

            return count;
        }
    }
}