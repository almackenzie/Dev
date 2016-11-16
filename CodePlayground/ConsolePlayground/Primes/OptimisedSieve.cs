using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Primes
{
    public class OptimisedSieve
    {
        private readonly int _maxValue;

        public OptimisedSieve(int maxValue)
        {
            _maxValue = maxValue;

            BuildNaiveSieve();
        }

        private List<bool> _sieve;

        private void BuildNaiveSieve()
        {
            _sieve = Enumerable.Range(0, _maxValue).Select(l => true).ToList();
            _sieve[0] = false;
            for (int i = 1; i < _maxValue; i++)
            {
                if (_sieve[i])
                {
                    int candidate = i + 1;
                    for (int j = candidate; j < _maxValue; j += candidate)
                    {
                        _sieve[j] = false;
                    }
                }
                
            }
            
        }

        public IEnumerable<int> GetPrimes()
        {
            return _sieve.Select((b, i) => new {IsPrime = b, Val = i+1}).Where(t => t.IsPrime).Select(t => t.Val);
        }

    }
}
