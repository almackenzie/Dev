using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Leader
{
    class EquiLeader
    {


// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            // iterate the array twice, once ftb, again btf. Each time calculate the leader at each index and store it. Finally iterate one final time to 
            // se where the indexes match.
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int[] upLeaders = new int[A.Length];
            int[] downLeaders = new int[A.Length];

            int currentLeader = A[0];

            for (int i = 0; i < A.Length; i++)
            {
                int val = A[i];
                if (!counts.ContainsKey(val))
                {
                    counts.Add(val, 0);
                }
                counts[val]++;
                if (counts[val] > counts[currentLeader])
                {
                    currentLeader = val;
                }
                upLeaders[i] = counts[currentLeader] > ((i + 1) / 2d) ? currentLeader : -1;
            }
            //Console.WriteLine(string.Join(",", upLeaders));

            currentLeader = A[A.Length - 1];
            counts = new Dictionary<int, int>();
            for (int i = A.Length - 1; i >= 0; i--)
            {
                int val = A[i];
                if (!counts.ContainsKey(val))
                {
                    counts.Add(val, 0);
                }
                counts[val]++;
                if (counts[val] > counts[currentLeader])
                {
                    currentLeader = val;
                }
                downLeaders[i] = counts[currentLeader] > ((A.Length - i) / 2d) ? currentLeader : -1;
            }

            //Console.WriteLine(string.Join(",", downLeaders));

            int equiLeaderCount = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (upLeaders[i] == downLeaders[i + 1] && upLeaders[i] != -1)
                {
                    equiLeaderCount++;
                }
            }

            return equiLeaderCount;

        }

            public class EquiLeaderTests
            {
                private EquiLeader _sut = new EquiLeader();

                [Test]
                public void EquiLeaderTest()
                {
                    Assert.AreEqual(2, _sut.solution(new[] { 4,3,4,4,4,2 }));
                    Assert.AreEqual(1, _sut.solution(new[] { 0, 0 }));
                    //Assert.AreEqual(-1, _sut.solution(new[] { 5, 5, 5, 2, 2, 2 }));
                    //Assert.AreEqual(0, _sut.solution(new[] { 2 }));
                    //Assert.AreEqual(0, _sut.solution(new[] { 5, 5, 5, 2, 2 }));
                    //Assert.AreEqual(4, _sut.solution(new[] { 5, 5, 2, 2, 2 }));
                }
            }

        }
}
