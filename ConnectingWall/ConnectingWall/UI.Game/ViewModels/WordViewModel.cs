using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectingWall.Common.Domain;
using Microsoft.Practices.Prism.ViewModel;

namespace ConnectingWall.Module.UI.Game.ViewModels
{
    [DebuggerDisplay("{Word}")]
    public class WordViewModel : NotificationObject
    {

        private readonly WordDefinition _wordDefinition;

        public WordViewModel(WordDefinition definition)
        {
            _wordDefinition = definition;
        }

        public WordDefinition WordDefinition
        {
            get { return _wordDefinition; }
        }

        public string Word
        {
            get
            {
                return _wordDefinition.Word;
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if(value != _isSelected)
                {
                    _isSelected = value;
                    RaisePropertyChanged(() => IsSelected);
                }
            }
        }

        private bool _isMatched;

        public bool IsMatched
        {
            get { return _isMatched; }
            set
            {
                if (value != _isMatched)
                {
                    _isMatched = value;
                    RaisePropertyChanged(() => IsMatched);
                }
            }
        }
    }
}
