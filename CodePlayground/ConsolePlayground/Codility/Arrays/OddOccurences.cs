using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Arrays
{
    class OddOccurences
    {
        public int solution(int[] A)
        {
            //Dictionary<int, int> counts = new Dictionary<int, int>();
            int result = 0;
            foreach(int a in A)
            {
                result = result ^ a;

                //if (!counts.ContainsKey(a))
                //{
                //    counts.Add(a, 1);
                //}
                //else
                //{
                //    counts[a]++;
                //}
            }
            //return counts.First(kvp => kvp.Value % 2 == 1).Key;
            return result;
        }
    }

    public class OddOccurencesTests
    {
        [Test]
        public void OddOccurencesTest()
        {
            OddOccurences oddOccurences = new OddOccurences();
            Assert.AreEqual(7, oddOccurences.solution(new[] { 9, 3, 9, 3, 9, 7, 9, 7, 7 }));
        }
    }

}
