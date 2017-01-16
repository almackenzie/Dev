using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Arrays
{
    class ArrayShift
    {
        public int[] solution(int[] A, int K)
        {
            if(A.Length == 0)
            {
                return new int[0];
            }

            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int actualShift = K % A.Length;

            if(actualShift == 0)
            {
                return A;
            }

            int[] destination = new int[A.Length];

            Array.Copy(A, A.Length - actualShift, destination, 0, actualShift);

            Array.Copy(A, 0, destination, actualShift, A.Length - actualShift);

            return destination;

        }
    }


    class ArrayShiftTests
    {
        [Test]
        public void ArrayShifttest()
        {
            ArrayShift arrayShift = new ArrayShift();

            CollectionAssert.AreEqual(new[] { 9, 7, 6, 3, 8 }, arrayShift.solution(new[] { 3, 8, 9, 7, 6 }, 3));
        }
    }

}
