using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.PrefixSums
{

    public class MinAvgTwoSlice
    {
        public int solution(int[] A)
        {
            int tail = 0;
            int head = 1;

            double currentMinAve = (A[head] + A[tail]) / ((head - tail) + 1);
            double currentAve = currentMinAve;
            int currentResult = tail;
            int currentLength = 2;

            do
            {
                double nextAve = ((currentAve * currentLength) + A[head]) / (currentLength + 1);

                if (nextAve < currentAve)
                {
                    // hold head, remove tail item and reset
                }
                else
                {
                    // just carry on
                }

                break;
            } while (true);
            return 0;
        }
    }

    public class MinAvgTwoSliceTests
    {
        MinAvgTwoSlice _sut = new MinAvgTwoSlice();

        [Test]
        public void MinAvgTwoSliceTest()
        {
            Assert.AreEqual(1, _sut.solution(new[] { 4,2,2,5,1,5,8 }));
        }
    }
}
