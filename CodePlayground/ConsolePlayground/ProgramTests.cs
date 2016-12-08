using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayground.DynamicProgramming;
using ConsolePlayground.MaximumSumPath;
using ConsolePlayground.Primes;
using NUnit.Framework;

namespace ConsolePlayground
{
    public class ProgramTests
    {
        [Test]
        public void SquareRootTests([Values(8, 1, 3, 4,9, 2045867)] double n, [Values(0.001, 0.0001, 0.1)] double precision)
        {
            var result = Program.FindSquareRoot(n, precision);
            Console.WriteLine("result: " + result);
            Console.WriteLine("actual: " + Math.Sqrt(n));
            Assert.LessOrEqual(Math.Sqrt(n) - result, precision);
        }

        [Test]
        public void PrimeTests()
        {
            var sieves = new List<IPrimeSieve>()
            {
                //new SimpleSieve(10),
                new HalfSizeSieve(10),
            };

            foreach (var sieve in sieves)
            {
                CollectionAssert.AreEqual(new[] { 2, 3, 5, 7 }, sieve.GetPrimes());
            }
            
            sieves = new List<IPrimeSieve>()
            {
                //new SimpleSieve(100),
                new HalfSizeSieve(100),
            };

            var numbers = new[]
                {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

            foreach (var sieve in sieves)
            {
                CollectionAssert.AreEqual(numbers, sieve.GetPrimes());

                for (int i = 0; i < 100; i++)
                {
                    Assert.True((numbers.Contains(i) && sieve.IsPrime(i)) || !(numbers.Contains(i) || sieve.IsPrime(i)));
                }
            }


        }

        [Test]
        public void PyramidMaxSumTests()
        {
            PyramidDefinition pyramid = new PyramidDefinition(new int[][]
            {
                new [] {55},
                new [] {94, 48},
                new [] {95, 30, 96},
                new [] {77, 71, 26, 67},
            });

            Assert.AreEqual(321, PyramidMaxSumPath.MaxPath(pyramid));

            PyramidDefinition pyramid2 = new PyramidDefinition(new int[][]
            {
                new [] {1},
                new [] {1, 1},
                new [] {1, 100, 1},
                new [] {1, 1, 1, 1},
            });

            Assert.AreEqual(103, PyramidMaxSumPath.MaxPath(pyramid2));

        }

        [Test]
        public void CoinSumTests()
        {
            int target = 11;

            List<int> coinValues = new List<int>() {2,3,5};

            Assert.AreEqual(target, CoinSums.GetCoinSumsTotalling(coinValues, target).Sum());

            CollectionAssert.AreEquivalent(new[] {5,3,3}, CoinSums.GetCoinSumsTotalling(coinValues, target));
        }

        [Test]
        public void NonDecreasingSequenceTests()
        {
            CollectionAssert.AreEqual(new List<int>() { 3,4,8}, NonDecreasingSequence.FindLongestNonDecreasingSequence(new [] {5,3,4,8,6,7}));
        }

        [Test]
        public void AppleCountingTest()
        {
            Assert.AreEqual(8, AppleCounter.GetMaxApples(new [,]
            {
                {1,3 },
                {2,4 }
            }));
        }

    }
}
