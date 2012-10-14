using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Module.UI.Game.Models
{
    public class WordDefinition
    {
        private readonly string _word;

        public WordDefinition(string word)
        {
            _word = word;
        }

        public string Word
        {
            get
            {
                return _word;
            }
        }

    }
}
