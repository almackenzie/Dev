using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.MaximumSumPath
{
    public class PyramidMaxSumPath
    {
        public static int MaxPath(PyramidDefinition pyramid)
        {

            for (int i = pyramid.Rows.Length - 1; i > 0; i--)
            {
                // for each row, take the highest from each pair and add to the row above

                int[] row = pyramid.Rows[i];
                int[] previousRow = pyramid.Rows[i-1];

                for (int j = 0; j < row.Length-1; j++)
                {
                    previousRow[j] += Math.Max(row[j], row[j+1]);
                }
            }

            return pyramid.Rows[0][0];

        }
    }

}
