using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Primes
{
    public class HalfSizeSieve : IPrimeSieve
    {
        private readonly int _maxValue;

        public HalfSizeSieve(int maxValue)
        {
            _maxValue = maxValue;

            BuildSieve();
        }

        private List<bool> _sieve;

        protected virtual int GetSieveSize(int n )
        {
            return n/2;
        }

        protected virtual void BuildSieve()
        {
            _sieve = Enumerable.Range(0, GetSieveSize(_maxValue)).Select(l => true).ToList();
            //_sieve[0] = true; // 1 is non-prime, 2 is prime, but these are special cases and handled in the isprime functions
            
            for (int i = 2; i < _maxValue; i++)
            {

                // on each iteration, we are testing this value from the original range
                int candidate = i + 1;
                
                if (!IsCandidate(candidate))
                {
                    // any even numbers except 2 are non prime, no need to test or store them
                    continue;
                }

                int index = IndexFunc(candidate);

                if (_sieve[index])
                {
                    // this one must be prime, switch off its mulptiples
                    
                    for (int j = candidate + candidate; j < _maxValue; j += candidate)
                    {
                        if (!IsCandidate(j))
                        {
                            continue;
                        }
                        _sieve[IndexFunc(j)] = false;
                    }
                }

            }

        }

        protected virtual bool IsCandidate(int n)
        {
            return (n%2 != 0) || (n == 2);
        }

        protected virtual int IndexFunc(int i)
        {
            return i/2;
        }

        protected virtual int DeIndexFunc(int i)
        {
            if (i == 0)
            {
                return 2;
            }
            return i * 2 + 1;
        }

        public bool IsPrime(int n)
        {
            if (n == 0 || n == 1)
            {
                return false;
            }
            if (IsCandidate(n))
            {
                return _sieve[IndexFunc(n)];
            }
            return false;
        }

        public IEnumerable<int> GetPrimes()
        {
            return _sieve.Select((b, i) => new { IsPrime = b, Val = DeIndexFunc(i) }).Where(t => t.IsPrime).Select(t => t.Val);
        }
    }



    public class SixesSieve : HalfSizeSieve
    {
        public SixesSieve(int maxValue) : base(maxValue)
        {
        }

        protected override bool IsCandidate(int n)
        {
            return (n + 1)%6 == 0 || (n - 1)%6 == 0;
        }

        protected override int GetSieveSize(int n)
        {
            return (n/6) * 2;
        }

        protected override int IndexFunc(int i)
        {
            return i/6;
        }
    }
}
