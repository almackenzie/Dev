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

            double rollingAve = 0;

            int currentResult = 0;
            double currentMin = double.NaN;

            // 2 slices
            rollingAve = (A[0] + A[1]) / 2d;
            currentMin = rollingAve;

            for (int i = 2; i < A.Length; i++)
            {
                rollingAve = ((rollingAve * 2) - A[i - 2] + A[i]) / 2d;
                if(rollingAve < currentMin)
                {
                    currentMin = rollingAve;
                    currentResult = i - 1;
                }
            }

            if(A.Length > 2)
            {
                rollingAve = (A[0] + A[1] + A[2]) / 3d;
                currentMin = Math.Min(rollingAve, currentMin);
                // 3slices
                for (int i = 3; i < A.Length; i++)
                {
                    rollingAve = ((rollingAve * 3) - A[i - 3] + A[i]) / 3d;
                    if (rollingAve < currentMin)
                    {
                        currentMin = rollingAve;
                        currentResult = i - 2;
                    }
                }
            }

            return currentResult;







            /* old2

            int tail = 0;
            int head = 1;
            double currentAverage = 0;
            double minAverage = double.NaN;
            int currentResult = 0;
            bool pushingAhead = true;
            double previousAverage = 0;

            do
            {
                previousAverage = currentAverage;
                int length = (head - tail) + 1;
                if (length == 2)
                {
                    currentAverage = (A[tail] + A[head]) / 2d;
                }
                else
                {
                    if (pushingAhead)
                    {
                        currentAverage = ((previousAverage * (length - 1)) + A[head]) / length;
                    }
                    else
                    {
                        currentAverage = ((previousAverage * (length + 1)) - A[tail -1]) / length;
                    }
                }

                if(double.IsNaN(minAverage) || currentAverage < minAverage)
                {
                    minAverage = currentAverage;
                    currentResult = tail;
                }

                // stop pushing ahead when the current average is strictly higher than the previous average, or head goes off the end of the array
                // stop dragging the tail when the length is two, and reset to make head = tail, and head = head + 1
                if (pushingAhead)
                {
                    if ((length != 2 && currentAverage > previousAverage) || head == A.GetUpperBound(0))
                    {
                        pushingAhead = false;
                                                
                        tail++;
                        head--;

                        if(tail >= head)
                        {
                            break;
                        }

                        currentAverage = ((currentAverage * length) - A[head+1]) / (length - 1);
                    }
                    else
                    {
                        head++;
                    }
                }
                else
                {
                    if(length == 2)
                    {
                        pushingAhead = true;
                        tail = head;
                        head++;
                        if(head > A.GetUpperBound(0))
                        {
                            break;
                        }
                    }
                    else
                    {
                        tail++;
                    }
                }
                
            } while (true);

            return currentResult;
            */
        }
    }

    public class MinAvgTwoSliceTests
    {
        MinAvgTwoSlice _sut = new MinAvgTwoSlice();

        [Test]
        public void MinAvgTwoSliceTest()
        {
            Assert.AreEqual(0, _sut.solution(new[] { 4, 10, 4 }));
            Assert.AreEqual(0, _sut.solution(new[] { 4, 2 }));
            Assert.AreEqual(1, _sut.solution(new[] { 4, 2, 2, 5, 1, 5, 8 }));
            Assert.AreEqual(2, _sut.solution(new[] { 1, 10, 1, 1, 1 }));

            Assert.AreEqual(0, _sut.solution(new[] { 1, 10, 9, 8, 7 }));

            Assert.AreEqual(0, _sut.solution(new[] { 1, 10, 9, 8, 7 }));

            Assert.AreEqual(5, _sut.solution(new[] { 10, 10, -1, 2, 4, -1, 2, -1 }));

        }
    }
}
