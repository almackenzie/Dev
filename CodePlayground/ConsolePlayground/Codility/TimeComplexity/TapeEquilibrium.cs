using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.TimeComplexity
{
    class TapeEquilibrium
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] sums = new int[A.Length];

            sums[A.Length - 1] = A[A.Length - 1];

            for (int i = sums.Length - 2; i >=0; i--)
            {
                sums[i] = sums[i+1] + A[i];
            }

            int currentMin = int.MaxValue ;
            int currentCount = 0;
            for(int i = 0; i < A.Length - 1; i++)
            {
                currentCount += A[i];
                int difference = Math.Abs(currentCount - sums[i + 1]);
                if(difference < currentMin)
                {
                    currentMin = difference;
                }
            }

            return currentMin;

        }
        
    }

    public class TapeEquilibriumTests
    {
        [Test]
        public void TapeEquilibriumTest()
        {
            TapeEquilibrium tapeEquilibrium = new TapeEquilibrium();
            Assert.AreEqual(1, tapeEquilibrium.solution(new[] { 3, 1, 2, 4, 3 }));

            Assert.AreEqual(0, tapeEquilibrium.solution(new[] { 8,8,8,8 }));
        }
    }
}
