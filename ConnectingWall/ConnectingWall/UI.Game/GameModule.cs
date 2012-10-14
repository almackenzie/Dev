using ConnectingWall.Module.UI.Game.ViewModels;
using ConnectingWall.Module.UI.Game.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingWall.Module.UI.Game
{
    public class GameModule : IModule
    {

        private IUnityContainer _container;

        public GameModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.Resolve<IRegionManager>().RegisterViewWithRegion("GameRegion", () => 
                {            
                    GameViewModel gameViewModel = new GameViewModel(_container);
                    GameView gameView = new GameView() { DataContext = gameViewModel };
                    return gameView;
                });
        }
    }
}
