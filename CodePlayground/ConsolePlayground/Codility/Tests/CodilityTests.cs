using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Tests
{
    [TestFixture]
    public class CodilityTests
    {
        [Test]
        public void WellFormedStringsTest()
        {
            WellFormedStrings.Solution solution = new WellFormedStrings.Solution();

            Assert.AreEqual(0, solution.solution("())"));
            Assert.AreEqual(1, solution.solution("(()(())())"));

        }
    }
}
