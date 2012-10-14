using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Module.UI.Game.Models
{
    public class GroupDefinition
    {
        private readonly string _description;
        private readonly WordDefinition[] _words;

        public GroupDefinition(string description, WordDefinition[] words)
        {
            _description = description;
            _words = words;
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public WordDefinition[] Words
        {
            get
            {
                return _words;
            }
        }

    }
}
