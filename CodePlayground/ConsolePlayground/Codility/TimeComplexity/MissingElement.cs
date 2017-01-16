using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.TimeComplexity
{
    class MissingElement
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            long sumElements = 0;
            int i = 0;
            for (i = 0; i < A.Length; i++)
            {
                sumElements += A[i];
            }
            // sum of first n ints is n(n+1)/2
            return (int)(((i+1)*(i+2)/2) - sumElements);
        }
    }

    public class MissingElementTests
    {
        [Test]
        public void MissingElementTest()
        {
            MissingElement missingElement = new MissingElement();
            Assert.AreEqual(5, missingElement.solution(new[] { 2,3,4,1 }));
            Assert.AreEqual(1, missingElement.solution(new[] { 2 }));
            Assert.AreEqual(2, missingElement.solution(new[] { 1 }));
            Assert.AreEqual(1, missingElement.solution(new int[0] ));
        }
    }
}
