using NUnit.Framework;
using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Iterations
{
    class BinaryGap
    {
        public int solution(int N)
        {
            int maxGap = 0;
            int bitwiseWith = 1;
            bool isCounting = false;
            int currentGap = 0;
            
            while(bitwiseWith <= N)
            {
                bool isBitSet = (N & bitwiseWith) == bitwiseWith;

                if (isBitSet)
                {
                    isCounting = true;
                    maxGap = Max(currentGap, maxGap);
                    currentGap = 0;
                }
                else
                {
                    if (isCounting)
                    {
                        currentGap++;
                    }
                }

                if(bitwiseWith > int.MaxValue / 2)
                {
                    break;
                }

                bitwiseWith <<= 1;
            }
            return maxGap;
        }
    }

    class BinaryGapTests
    {
        [Test]
        public void BinaryGaptest()
        {
            BinaryGap binaryGap = new BinaryGap();
            Assert.AreEqual(0, binaryGap.solution(1));
            Assert.AreEqual(0, binaryGap.solution(8));
            Assert.AreEqual(2, binaryGap.solution(9));
            Assert.AreEqual(4, binaryGap.solution(529));
            Assert.AreEqual(5, binaryGap.solution(1041));
            var x = binaryGap.solution(1376796946);
        }
    }


}
