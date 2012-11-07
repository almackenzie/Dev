using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectingWall.Common.Domain;

namespace ConnectingWall.Common.Interfaces
{
    public interface IGroupDefinitionService
    {
        GroupDefinition[] GetGroups(int groupSize, int numberOfgroups);
    }
}
