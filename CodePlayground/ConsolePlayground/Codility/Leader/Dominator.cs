using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Leader
{
    class Dominator
    {

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A.Length == 0) return -1;
            if (A.Length == 1) return 0;

            Queue<int> q = new Queue<int>(2);
            int depth = 0;
            int currentLeader = 0;
            //q.Enqueue(A[0]);
            int currentFoundIndex = 0;

            for(int i = 0; i< A.Length; i++)
            {
                int val = A[i];

                if(depth == 0)
                {
                    depth++;
                    currentLeader = val;
                    currentFoundIndex = i;
                }
                else
                {
                    if(val == currentLeader)
                    {
                        // this is match - just increase the depth
                        depth++;
                    }
                    else
                    {
                        // this is a pair of different elements
                        depth--;
                    }
                }
            }

            return A.Where(i => i == currentLeader).Count() > A.Length / 2d ? currentFoundIndex : -1;

        }
        
    }

    public class DominatorTests
    {
        private Dominator _sut = new Dominator();

        [Test]
        public void DominatorTest()
        {
            Assert.AreEqual(6, _sut.solution(new[] { 3, 4, 3, 2, 3, -1, 3, 3 }));
            Assert.AreEqual(-1, _sut.solution(new[] { 3, 4, 5, 2, 3, -1, 3, 3 }));
            Assert.AreEqual(-1, _sut.solution(new[] { 5,5,5,2,2,2 }));
            Assert.AreEqual(0, _sut.solution(new[] { 2 }));
            Assert.AreEqual(0, _sut.solution(new[] { 5,5,5,2,2 }));
            Assert.AreEqual(4, _sut.solution(new[] { 5, 5, 2, 2, 2 }));
        }
    }

}
