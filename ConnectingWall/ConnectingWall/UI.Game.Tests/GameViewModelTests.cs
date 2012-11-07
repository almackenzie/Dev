using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectingWall.Common.Domain;
using ConnectingWall.Common.Interfaces;
using ConnectingWall.Module.UI.Game.Models;
using ConnectingWall.Module.UI.Game.ViewModels;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UI.Game.Tests
{
    [TestClass]
    public class GameViewModelTests
    {
        [TestMethod]
        public void When_Starting_Game_All_Words_Are_Populated()
        {
            GameViewModel viewModel = GetGameViewModel();

            GroupDefinition[] groups = GetGroups();

            CollectionAssert.AreEqual(groups.SelectMany(gd => gd.Words.Select(wd => wd.Word)).ToArray()
                , viewModel.Groups.SelectMany(gd => gd.Words.Select(wd => wd.Word)).ToArray());

        }

        private GameViewModel GetGameViewModel()
        {
            IUnityContainer container = new UnityContainer();

            Mock<IGroupDefinitionService> groupDefinitionServiceMock = new Mock<IGroupDefinitionService>();

            groupDefinitionServiceMock.Setup(gds => gds.GetGroups(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(GetGroups());

            container.RegisterInstance(groupDefinitionServiceMock.Object);

            GameViewModel viewModel = new GameViewModel(container);
            return viewModel;
        }

        [TestMethod]
        public void When_Four_Unmatched_Items_Are_Clicked_They_Are_All_Unselected()
        {
            GameViewModel viewModel = GetGameViewModel();

            // pick three from one group and one from another to ensure we don't accidentally end up
            // picking a valid group!!
            
            var wordsToSelect = viewModel.Groups[0].Words.Take(2).Concat(viewModel.Groups[1].Words.Take(2))
                .Select(wd => viewModel.Words.Single(wvm => wvm.Word == wd.Word));

            foreach (var wordViewModel in wordsToSelect)
            {
                wordViewModel.IsSelected = true;
            }

            Assert.IsTrue(viewModel.Words.All(wvm => !wvm.IsSelected));

        }

        [TestMethod]
        public void When_Four_Matched_Items_Are_Selected_They_Move_To_The_Top_Of_The_List()
        {
            GameViewModel viewModel = GetGameViewModel();

            // pick three from one group and one from another to ensure we don't accidentally end up
            // picking a valid group!!

            for(int i = 0; i < 3; i++)
            {
                var wordsToSelect = viewModel.Groups[i].Words
                    .Select(wd => viewModel.Words.Single(wvm => wvm.Word == wd.Word)).ToList();

                CollectionAssert.AreNotEqual(viewModel.Words.Skip(i * 4).Take(4).OrderBy(wvm => wvm.Word).ToArray(), wordsToSelect.OrderBy(wvm => wvm.Word).ToArray());

                foreach (var wordViewModel in wordsToSelect)
                {
                    wordViewModel.IsSelected = true;
                }

                Assert.IsTrue(viewModel.Words.All(wvm => !wvm.IsSelected));
                Assert.IsTrue(wordsToSelect.All(wvm => wvm.IsMatched == true));

                CollectionAssert.AreEqual(viewModel.Words.Skip(i * 4).Take(4).OrderBy(wvm => wvm.Word).ToArray(), wordsToSelect.OrderBy(wvm => wvm.Word).ToArray());    
            }

            var finalWords = viewModel.Groups[3].Words
                .Select(wd => viewModel.Words.Single(wvm => wvm.Word == wd.Word)).ToList();

            CollectionAssert.AreEqual(viewModel.Words.Skip(12).Take(4).OrderBy(wvm => wvm.Word).ToArray(), finalWords.OrderBy(wvm => wvm.Word).ToArray());




            
            
        }

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

        


    
    }
// ReSharper restore InconsistentNaming
}
