using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ConsolePlayground.Codility.Sorting
{
    public class DiscIntersections
    {
        [DebuggerDisplay("Lo {Lo} - Hi {Hi}")]
        struct LineSection
        {
            public LineSection(long lo, long hi)
            {
                Lo = lo;
                Hi = hi;
            }

            public long Lo { get; }
            public long Hi { get; }

        }

        [DebuggerDisplay("{Location} - {IsStart}")]
        public class Edge
        {
            public long Location { get; set; }
            public bool IsStart { get; set; }
        }

        public class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                int loc = x.Location.CompareTo(y.Location);
                if (loc == 0)
                {
                    return -x.IsStart.CompareTo(y.IsStart);
                }
                return loc;
            }
        }

        public int solution(int[] A)
        {

            IEnumerable<Edge> allItems = A.SelectMany((val, i) =>
            {
                
                return new Edge[]
                {
                    new Edge{Location = (long)i - val, IsStart = true },
                    new Edge{Location = (long)i + val, IsStart = false }
                };
            }).OrderBy(e => e, new EdgeComparer());

            long currentOpenDiscs = 0;
            long currentOverlaps = 0;

            foreach(var edge in allItems)
            {
                if (edge.IsStart)
                {
                    currentOpenDiscs++;
                    currentOverlaps += (currentOpenDiscs - 1);
                }
                else
                {
                    currentOpenDiscs--;
                }

                if(currentOverlaps > 10000000L)
                {
                    return -1;
                }
            }



            return (int)currentOverlaps;

        }



    }

    //public int solution2(int[] A)
    //{
    //    // write your code in C# 6.0 with .NET 4.5 (Mono)
    //    List<LineSection> sortedByLo = A
    //        .Select((v, i) => new { lo = i - v, hi = i + v })
    //        .OrderBy(t => t.lo)
    //        .ThenBy(t => t.hi)
    //        .Select((t, j) => new LineSection(t.lo, t.hi))
    //        .ToList();

    //    int[] sortedHis = sortedByLo.Select(ls => ls.Hi).OrderBy(i => i).ToArray();

    //    int overlaps = 0;

    //    //foreach(LineSection ls in sortedByLo)
    //    for (int i = 0; i < A.Length; i++)
    //    {
    //        LineSection ls = sortedByLo[i];

    //        int hiRank = Array.BinarySearch(sortedHis, ls.Hi);

    //        overlaps += (hiRank - i);

    //        //hiRank -= i;

    //        // however
    //        //overlaps += ((hiRank) * (hiRank + 1)) / 2; 

    //    }
    //    return overlaps;

    //}

    public class DiscintersectionsTests
    {
        DiscIntersections _sut = new DiscIntersections();

        [Test]
        public void DiscIntersectionsTest()
        {
            //Assert.AreEqual(1, _sut.solution(new int[] { 0, 1 }));
            //Assert.AreEqual(1, _sut.solution(new int[] { 1, 0 }));
            //Assert.AreEqual(0, _sut.solution(new int[] { 0, 0 }));

            //Assert.AreEqual(11, _sut.solution(new int[] { 1, 5, 2, 1, 4, 0 }));
            Assert.AreEqual(2, _sut.solution(new int[] { 1, 2147483647, 0 }));
        }
    }
}
