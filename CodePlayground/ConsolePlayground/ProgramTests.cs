using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var sieve = new OptimisedSieve(10);
            CollectionAssert.AreEqual(new[] {2,3,5,7}, sieve.GetPrimes());
        }

    }
}
