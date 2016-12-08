using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayground.Extensions;

namespace ConsolePlayground.DynamicProgramming
{
    public class CoinSums
    {
        public static List<int> GetCoinSumsTotalling(List<int> coinValues, int target)
        {
            
            List<int>[] results = new List<int>[target + 1 ];

            for (int i = 0; i < results.Length; i++)
            {
                if (i == 0)
                {
                    // base case - best case is an empty list
                    results[i] = new List<int>();
                    continue;
                }

                // now add each coin the base case, and update relevant slots
                var previous = results[i - 1];
                if (previous == null)
                {
                    continue;
                }
                var previousSum = previous.Sum();
                foreach (int coin in coinValues)
                {
                    var result = previousSum + coin;

                    if (result <= target)
                    {
                        if (results[result] == null || results[result].Count > previous.Count + 1)
                        {
                            results[result] = new List<int>(previous.Concat(coin.AsEnumerable()));
                        }
                    }
                }
            }

            return results[target];
            
        }



    }



}
