using ConnectingWall.Module.UI.Game.Models;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Module.UI.Game.ViewModels
{
    public class GameViewModel : NotificationObject
    {

        private IUnityContainer _container;

        public GameViewModel(IUnityContainer container)
        {
            Random rng = new Random();
            _container = container;
            Title = "Game " + DateTime.Now;
            _groups = GetGroups();
            _words = _groups.SelectMany(gd => gd.Words).OrderBy(wd => rng.Next()).ToArray();
        }

        private readonly GroupDefinition[] _groups;

        private GroupDefinition[] GetGroups()
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

        public string Title { get; set; }

        private readonly WordDefinition[] _words;

        public WordDefinition[] Words
        {
            get
            {
                return _words;
            }
        }

    }
}
