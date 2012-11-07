using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectingWall.Common.Domain;
using ConnectingWall.Common.Interfaces;

namespace ConnectingWall.Common.Services
{
    public class GroupDefinitionService : IGroupDefinitionService 
    {
        public GroupDefinition[] GetGroups(int groupSize, int numberOfgroups)
        {
            return new[]
            {
                new GroupDefinition("Begin with A", new[]
                {
                    new WordDefinition("Animal"),
                    new WordDefinition("Alphabet"),
                    new WordDefinition("Arithmetic"),
                    new WordDefinition("Admonished"),
                }),
                new GroupDefinition("Begin with D", new[]
                {
                    new WordDefinition("Dragon"),
                    new WordDefinition("Dirtbike"),
                    new WordDefinition("Dog"),
                    new WordDefinition("Dapper"),
                }),
                new GroupDefinition("Begin with G", new[]
                {
                    new WordDefinition("Gibbon"),
                    new WordDefinition("Gamble"),
                    new WordDefinition("Grenade"),
                    new WordDefinition("Grass"),
                }),
                new GroupDefinition("Begin with Y", new[]
                {
                    new WordDefinition("Yacht"),
                    new WordDefinition("Yahtzee"),
                    new WordDefinition("Yoghurt"),
                    new WordDefinition("Youth"),
                })
            };

        }
    }
}
