using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayground.Extensions;

namespace ConsolePlayground.DynamicProgramming
{
    public class NonDecreasingSequence
    {

        public static List<int> FindLongestNonDecreasingSequence(int[] values)
        {
            //int startIndex = -1;
            //int currentSequenceLength = -1;
            //int maxSequenceLength = -1;
            //bool inSequence = false;

            //for (int i = 0; i < values.Length; i++)
            //{
            //    if (!inSequence)
            //    {
                    
            //    }
            //}

            List<int>[] sequences = new List<int>[values.Length];
            List<int> longestSequence = new List<int>();
            for (int i = 0; i < sequences.Length; i++)
            {
                if (i == 0)
                {
                    sequences[i] = new List<int>() {values[0]};
                    longestSequence = sequences[i];
                }
                else if (values[i] >= values[i - 1])
                {
                    sequences[i] = sequences[i - 1].Concat(values[i].AsEnumerable()).ToList();
                    if (sequences[i].Count > longestSequence.Count)
                    {
                        longestSequence = sequences[i];
                    }
                }
                else
                {
                    sequences[i] = new List<int>() { values[i] };
                }
               
            }

            return longestSequence;
            



        }

    }
}
