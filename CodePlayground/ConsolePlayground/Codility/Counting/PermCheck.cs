using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Counting
{
    public class PermCheck
    {
        public int solution(int[] A)
        {
            bool[] res = new bool[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                if(A[i] > A.Length || A[i] <= 0 || res[A[i] - 1])
                {
                    return 0;
                }
                else
                {
                    res[A[i] - 1] = true;
                }
            }
            return 1;
        }
    }

    public class PermCheckTests
    {
        [Test]
        public void PermCheckTest()
        {
            PermCheck permCheck = new PermCheck();
            Assert.AreEqual(1, permCheck.solution(new[] { 4,1,3,2 }));
            Assert.AreEqual(0, permCheck.solution(new[] { 4, 1, 2 }));

            Assert.AreEqual(1, permCheck.solution(new[] { 1,2,3,4 }));

            Assert.AreEqual(0, permCheck.solution(new[] { 5,12,91 }));

            Assert.AreEqual(0, permCheck.solution(new[] { 0,0,0,4 }));
            Assert.AreEqual(0, permCheck.solution(new[] { 0, 0, 2, 2 }));

        }
    }


}
