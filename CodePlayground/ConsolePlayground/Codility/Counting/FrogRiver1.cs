using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Counting
{

    public class FrogRiverOne
    {
        public int solution(int X, int[] A)
        {
            bool[] leaves = new bool[X];
            int covered = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int current = A[i];
                if(current <= X)
                {
                    if(!leaves[current - 1])
                    {
                        leaves[current - 1] = true;
                        covered++;
                        if(covered == X)
                        {
                            return i;
                        }
                    };
                     
                }
            }
            return -1;
        }
    }

    public class FrogRiverOneTests
    {
        FrogRiverOne _sut = new FrogRiverOne();

        [Test]
        public void FrogRiverOneTest()
        {
            Assert.AreEqual(6, _sut.solution(5, new[] { 1, 3, 1, 4, 2, 3, 5, 4 }));
        }
    }
}
