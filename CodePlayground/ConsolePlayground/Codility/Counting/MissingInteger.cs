using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Counting
{
    public class MissingInteger
    {
        public int solution(int[] A)
        {

            HashSet<int> seen = new HashSet<int>();

            int guess = 1;

            foreach(int i in A)
            {
                if(i == guess)
                {
                    guess = UpdateGuess(guess, seen);
                }
                else if(i > guess && !seen.Contains(i))
                {
                    seen.Add(i);
                }
            }

            return guess;
            
        }

        private int UpdateGuess(int i, HashSet<int> seen)
        {
            do
            {
                i++;
            } while (seen.Contains(i));
            return i;
        }
    }

    public class MissingIntegerTests
    {
        MissingInteger missinginteger = new MissingInteger();

        [Test]
        public void MissingIntegerTest()
        {
            Assert.AreEqual(5, missinginteger.solution(new[] { 1, 3, 6, 4, 1, 2 }));

            Assert.AreEqual(3, missinginteger.solution(new[] {2,1,4}));

            Assert.AreEqual(3, missinginteger.solution(new[] { 1,2,4 }));
        }
    }

}
