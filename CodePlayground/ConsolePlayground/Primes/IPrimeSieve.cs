using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Primes
{
    public interface IPrimeSieve
    {
        bool IsPrime(int n);
        IEnumerable<int> GetPrimes();
    }
}
