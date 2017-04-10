using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.StacksAndQueues
{
    class Fish
    {
        public int solution(int[] A, int[] B)
        {
            int killed = 0;
            //int currentDownstream = -1;
            Stack<int> downstreams = new Stack<int>();

            for(int i = 0; i < A.Length; i++)
            {
                if(B[i] == 0)
                {
                    // this one is going upstream
                    while (downstreams.Count != 0)
                    {
                        int currentDownstream = downstreams.Pop();
                        if (currentDownstream < A[i])
                        {
                            killed++;
                        }
                        else
                        {
                            killed++;
                            downstreams.Push(currentDownstream);
                            break;
                        }
                    }
                }
                else
                {
                    // this one is going downstream
                    downstreams.Push(A[i]);
                }

            }
            return A.Length - killed;
        }
        
    }

    public class FishTests
    {
        Fish _sut = new Fish();

        [Test]
        public void FishTest()
        {
            Assert.AreEqual(2, _sut.solution(new[] { 4,3,2,1,5 }, new[] { 0,1,0,0,0 }));
            Assert.AreEqual(5, _sut.solution(new[] { 4, 3, 2, 1, 5 }, new[] { 0, 0, 0, 0, 0 }));
            Assert.AreEqual(5, _sut.solution(new[] { 4, 3, 2, 1, 5 }, new[] { 1,1,1,1,1 }));
            Assert.AreEqual(1, _sut.solution(new[] { 1,2,3,4,5 }, new[] { 1, 1, 1, 1, 0 }));
        }
    }


}
