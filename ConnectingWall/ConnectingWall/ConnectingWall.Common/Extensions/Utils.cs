using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectingWall.Common.Domain;

namespace ConnectingWall.Common.Extensions
{
    public static class Utils
    {
        public static bool IsInGroup(this WordDefinition source, GroupDefinition group)
        {
            foreach (WordDefinition wordDefinition in group.Words)
            {
                if(source == wordDefinition)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
