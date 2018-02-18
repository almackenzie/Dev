using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Codility.Slices
{
    class MaximumSlices
    {

        public int solution(int[] A)
        {
            return 0;
        }

    }

    public class MaximumSlicesTests
    {
        private MaximumSlices _sut = new MaximumSlices();

        [Test]
        public void MaximumSlicesTest()
        {
            Assert.AreEqual(17, _sut.solution(new[] { 3, 2, 6, -1, 4, 5, -1, 2 }));
            //Assert.AreEqual(-1, _sut.solution(new[] { 3, 4, 5, 2, 3, -1, 3, 3 }));
            //Assert.AreEqual(-1, _sut.solution(new[] { 5, 5, 5, 2, 2, 2 }));
            //Assert.AreEqual(0, _sut.solution(new[] { 2 }));
            //Assert.AreEqual(0, _sut.solution(new[] { 5, 5, 5, 2, 2 }));
            //Assert.AreEqual(4, _sut.solution(new[] { 5, 5, 2, 2, 2 }));
        }
    }
}
