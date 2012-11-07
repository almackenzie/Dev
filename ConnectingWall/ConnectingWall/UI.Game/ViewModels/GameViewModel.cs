using System.Collections;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using ConnectingWall.Common.Domain;
using ConnectingWall.Common.Interfaces;


using ConnectingWall.Common.Extensions;
using System.Reactive.Linq;
using System.Reactive;

namespace ConnectingWall.Module.UI.Game.ViewModels
{
    public class GameViewModel : NotificationObject
    {
        private IUnityContainer _container;

        private List<WordViewModel> _currentSelection = new List<WordViewModel>();

        private readonly Random _random = new Random();

        private int _matchedGroupCount = 0;

        public GameViewModel(IUnityContainer container)
        {
            
            _container = container;
            Title = "Game " + DateTime.Now;
            _groups = container.Resolve<IGroupDefinitionService>().GetGroups(4, 4);
            _words = GetEnsuredNonMatchedRows(_groups.SelectMany(gd => gd.Words).Select(wd => new WordViewModel(wd)).ToArray());

            foreach (var wordViewModel in Words)
            {
                wordViewModel.PropertyChanged += HandlePropertyChanged;
            }
        }

        private WordViewModel[] GetEnsuredNonMatchedRows(WordViewModel[] input)
        {
            WordViewModel[] rv = null;

            if(input.Length == 4)
            {
                return input;
            }

            bool isUnique = false;

            while(!isUnique)
            {
                rv = input.OrderBy(wd => _random.Next()).ToArray();

                bool foundNonUnique = false;
                for(int i = 0; i < input.Length; i += 4)
                {
                    if (IsAGroup(rv.Skip(i).Take(4)))
                    {
                        foundNonUnique = true;
                    }
                }
                isUnique = !foundNonUnique;
            }

            return rv;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsSelected")
            {
                WordViewModel source = (WordViewModel)sender;

                if(source.IsSelected)
                {
                    _currentSelection.Add(source);
                    Console.WriteLine("Selected " + source.Word);
                }
                else
                {
                    _currentSelection.Remove(source);
                    Console.WriteLine("Deselected " + source.Word);
                }

                if(_currentSelection.Count == 4)
                {
                    if(IsAGroup(_currentSelection))
                    {
                        foreach (WordViewModel wordViewModel in _currentSelection)
                        {
                            wordViewModel.IsMatched = true;
                        }
                        ReorderNewlyMatchedGroup();
                        _matchedGroupCount++;
                    }
                    foreach (WordViewModel wordViewModel in _currentSelection.ToArray())
                    {
                        wordViewModel.IsSelected = false;
                    }
                }
            }
        }

        private void ReorderNewlyMatchedGroup()
        {
            List<WordViewModel> currentlyMatchedItems = _words.Take(_matchedGroupCount*4).ToList();

            List<WordViewModel> newItems = _currentSelection.ToList();

            List<WordViewModel> remainder = GetEnsuredNonMatchedRows(_words.Except(newItems).Except(currentlyMatchedItems).ToArray()).ToList();

            // odd hack needed otherwise the UI displays different words to the underlying VMs
            _words = null;
            RaisePropertyChanged(() => Words);
            // end odd hack

            _words = currentlyMatchedItems.Concat(newItems).Concat(remainder).ToArray();
            
            RaisePropertyChanged(() => Words);
        }

        private bool IsAGroup(IEnumerable<WordViewModel> input)
        {
            return input.Select(wvm => wvm.WordDefinition.Group).Distinct().Count() == 1;
        }

        private readonly GroupDefinition[] _groups;

        public string Title { get; set; }

        private WordViewModel[] _words;

        public WordViewModel[] Words
        {
            get
            {
                return _words;
            }
        }

        public GroupDefinition[] Groups
        {
            get
            {
                return _groups;
            }
        }

    }
}
