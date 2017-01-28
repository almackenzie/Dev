using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.PrefixSums
{

    public class GenomicRangeQuery
    {
        struct Query
        {
            public Query(int lo, int hi)
            {
                Lo = lo;
                Hi = hi;
            }

            public int Lo { get; set; }
            public int Hi { get; set; }
        }

        public Dictionary<char, int> _impacts =
            new Dictionary<char, int>
            {
                {'A', 1},
                {'C', 2},
                {'G', 3},
                {'T', 4},
            };

        public int[] solution(string S, int[] P, int[] Q)
        {
            int queryCount = P.Length;
            int[] result = new int[queryCount];
            int[,] counters = new int[4, S.Length];

            counters[_impacts[S[0]]-1, 0] = 1;

            for (int i = 1; i < S.Length; i++)
            {
                int current = _impacts[S[i]];
                for (int j = 0; j <= 3; j++)
                {
                    if (current == (j + 1))
                    {
                        counters[j, i] = counters[j, i - 1] + 1;
                    }
                    else
                    {
                        counters[j, i] = counters[j, i - 1];
                    }
                }
            }

            for (int i = 0; i < P.Length; i++)
            {
                Query q = new Query(P[i], Q[i]);

                int currentLow = 5;

                if (q.Lo == q.Hi)
                {
                    currentLow = _impacts[S[q.Lo]];
                }
                else
                {
                    currentLow = _impacts[S[q.Lo]];

                    for (int j = 0; j <= 3; j++)
                    {
                        if (counters[j, q.Hi] > counters[j, q.Lo])
                        {
                            currentLow = Math.Min(j + 1, currentLow);
                            break;
                        }
                    }
                }

                result[i] = currentLow;
            }
            return result;
        }


        public int[] solutionSlo(string S, int[] P, int[] Q)
        {
            int queryCount = P.Length;
            int[] result = new int[queryCount];

            for(int i = 0; i<P.Length; i++)
            {
                Query q = new Query(P[i], Q[i]);
                int currentLow = 5;
                for(int j = q.Lo; j<=q.Hi; j++)
                {
                    int current = _impacts[S[j]];
                    if (current < currentLow)
                    {
                        currentLow = current;
                    }
                }
                result[i] = currentLow;
            }
            return result;
        }
    }

    public class GenomicRangeQueryTests
    {
        GenomicRangeQuery _sut = new GenomicRangeQuery();

        [Test]
        public void GenomicRangeQueryTest()
        {
            CollectionAssert.AreEqual(new[] { 2, 4, 1 },
                _sut.solution("CAGCCTA", new[] { 2, 5, 0 }, new[] { 4, 5, 6 }));

            CollectionAssert.AreEqual(new[] { 1,1,2 },
                _sut.solution("AC", new[] { 0,0,1 }, new[] { 0,1,1 }));

        }
    }
}
