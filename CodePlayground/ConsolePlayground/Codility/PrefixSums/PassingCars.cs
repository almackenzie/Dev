using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.PrefixSums
{

    public class PassingCars
    {
        public int solution(int[] A)
        {
            int zeroCount = 0;
            int pairs = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if(A[i] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    pairs += zeroCount;
                    if(pairs > 1000000000)
                    {
                        return -1;
                    }

                }
            }
            return pairs;

        }
    }

    public class PassingCarsTests
    {
        PassingCars _sut = new PassingCars();

        [Test]
        public void PassingCarsTest()
        {
            Assert.AreEqual(5, _sut.solution(new[] { 0, 1, 0, 1, 1 }));

            Assert.AreEqual(0, _sut.solution(new[] { 0, 0, 0, 0, 0 }));

            Assert.AreEqual(0, _sut.solution(new[] { 1, 1, 1, 1, 1, }));

            Assert.AreEqual(4, _sut.solution(new[] { 0, 1, 1, 1, 1, }));
        }
    }
}
